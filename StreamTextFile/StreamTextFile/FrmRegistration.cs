﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StreamTextFile
{
    public partial class FrmRegistration : Form
    {
        public FrmRegistration()
        {
            InitializeComponent();
        }

        private void FrmRegistration_Load(object sender, EventArgs e)
        {
            string[] ListOfProgram = new string[]{
                "BS Information Technology",
                "BS Computer Science",
                "BS Information Systems",
                "BS in Accountancy",
                "BS in Hospitality Management",
                "BS in Tourism Management"
            };

            for (int i = 0; i < 6; i++)
            {
                cbProg.Items.Add(ListOfProgram[i].ToString());
            }

            string[] Gender = new string[]
            {
                "Male",
                "Female"
            };

            for (int i = 0; i < 2; i++)
            {
                cbGender.Items.Add(Gender[i].ToString());
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string[] content =
                {
                lblStudNo.Text.ToString() + txtStudNo.Text,
                lblLname.Text.ToString() + txtLname.Text,
                lblFname.Text.ToString() + txtFname.Text,
                lblMI.Text.ToString() + txtMI.Text,
                lblAge.Text.ToString() + txtAge.Text,
                lblContact.Text.ToString() + txtContactNo.Text,
                lblProg.Text.ToString() + cbProg.Text,
                lblGender.Text.ToString() + cbGender.Text,
                lblBday.Text.ToString() + dtpBday.Value.ToString("yyyy-MM-dd")
            };

            MessageBox.Show("Successfully Registered");

            string fileName = txtStudNo.Text + ".txt";

            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, fileName)))
            {
                foreach (string line in content)
                {
                    outputFile.WriteLine(line);
                    Console.WriteLine(line);
                }
            }
        }

        private void btnRecord_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmStudentRecord frmStudentRecord = new FrmStudentRecord();
            frmStudentRecord.ShowDialog();
            this.Close();
        }
    }
}
