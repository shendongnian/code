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
                dt.Columns.Add("Title", typeof(string));
                dt.Columns.Add("Publish", typeof(DateTime));
                dt.Columns.Add("Author", typeof(string));
                dt.Rows.Add(new object[] {"Book A", DateTime.Parse("1/1/2016"), "Author A"});
                dt.Rows.Add(new object[] {"Book B", DateTime.Parse("1/2/2016"), "Author B"});
                dt.Rows.Add(new object[] {"Book C", DateTime.Parse("1/3/2016"), "Author C"});
                dataGridView1.DataSource = dt;
            }
        }
    }
