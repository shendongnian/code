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
            const string FILENAME = @"\temp\test.xml";
            public Form1()
            {
                InitializeComponent();
                DataSet ds = new DataSet();
                ds.ReadXml(FILENAME);
                dataGridView1.DataSource = ds.Tables[1];
            }
        }
    }
    ​
