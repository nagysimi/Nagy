using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserMaintenance.Entities;

namespace UserMaintenance
{
    public partial class Form1 : Form
    {
        BindingList<User> users = new BindingList<User>();
        public Form1()
        {
            InitializeComponent();
            lblLastName.Text = Resource1.FullName; // label1

            btnAdd.Text = Resource1.Add; // button1
            btnWrite.Text = Resource1.Write;
            btnDelete.Text = Resource1.Delete;

            listUsers.DataSource = users;
            listUsers.ValueMember = "ID";
            listUsers.DisplayMember = "FullName";
        }

        public object StreamWritter { get; private set; }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var u = new User()
            {
                FullName = txtLastName.Text,

            };
            users.Add(u);
        }

        private void btnWrite_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter sw = new StreamWriter(sfd.FileName))
                {
                    foreach (var u in users)
                    {
                        sw.Write(u.ID);
                        sw.Write(";");
                        sw.Write(u.FullName);
                        sw.WriteLine();
                    }
                }


            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (listUsers.SelectedItem == null) return;
            var törlendő = (User)listUsers.SelectedItem;
            users.Remove(törlendő);
            
           

        }
    }
}
