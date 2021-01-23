    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            DataTable dt = new DataTable();
            public Form1()
            {
                InitializeComponent();
                //initiailze the datatable
                dt.Columns.Add("Col 1", typeof(string));
                dt.Columns.Add("Col 2", typeof(string));
                dt.Columns.Add("Col 3", typeof(string));
                //add three rows
                dt.Rows.Add();
                dt.Rows.Add();
                dt.Rows.Add();
                dataGridView1.DataSource = dt;
            }
            private void button1_Click(object sender, EventArgs e)
            {
                //examples of filling table
                dt.Rows[0][0] = "X";
                dt.Rows[0][1] = "O";
                dt.Rows[0][2] = "X";
                dt.Rows[1][0] = "O";
                dt.Rows[1][1] = "X";
                dt.Rows[1][2] = "O";
                dt.Rows[2][0] = "X";
                dt.Rows[2][1] = "O";
                dt.Rows[2][2] = "X";
            }
        }
    }
    ​
