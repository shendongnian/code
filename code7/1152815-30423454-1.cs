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
                dt.Columns.Add("SN", typeof(string));
                dt.Columns.Add("Name", typeof(string));
                dt.Columns.Add("Subject", typeof(string));
                dt.Columns.Add("Topic", typeof(string));
                dt.Columns.Add("Subtopic", typeof(string));
                dt.Rows.Add(new object[] { "1.", "Mr.SK Jha", "Physics", "Optics", "Diffraction Interference" });
                dt.Rows.Add(new object[] { "", "", "", "Mechanics", "MKS" });
                dt.Rows.Add(new object[] { "", "", "", "Electromagnetic" });
                dt.Rows.Add(new object[] { 2, "Mr.XYZ", "Chemistry", "Inorganic", "Ethene" });
                dataGridView1.DataSource = dt;
            }
        }
    }
    ​
