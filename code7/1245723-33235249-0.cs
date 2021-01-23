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
            public Form1()
            {
                InitializeComponent();
                DataTable dt = new DataTable();
                dt.Columns.Add("ColA", typeof(int));
                dt.Columns.Add("ColB", typeof(string));
                dt.Rows.Add(new object [] {1,"a"});
                dt.Rows.Add(new object [] {2,"b"});
                dt.Rows.Add(new object [] {3,"c"});
                dt.Rows.Add(new object [] {4,"d"});
                dt.Rows.Add(new object [] {5,"e"});
                dataGridView1.DataSource = dt;
            }
        }
    }
    ​
