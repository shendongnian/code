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
            const string FILENAME = @"c:\temp\text.xml";
            public Form1()
            {
                InitializeComponent();
            }
            private void button1_Click(object sender, EventArgs e)
            {
                DataSet ds = new DataSet("Data Set");
                DataTable dt = new DataTable("Data");
                ds.Tables.Add(dt);
                dt.Columns.Add("Name", typeof(string));
                dt.Columns.Add("Value", typeof(string));
                dt.Rows.Add(new object[] { "Text Box 1", textBox1.Text });
                dt.Rows.Add(new object[] { "Text Box 2", textBox2.Text });
                dt.Rows.Add(new object[] { "Text Box 3", textBox3.Text });
                dt.Rows.Add(new object[] { "Text Box 4", textBox4.Text });
                ds.WriteXml(FILENAME, XmlWriteMode.WriteSchema);
                //use following to read
                ds.ReadXml(FILENAME);
                textBox1.Text = ds.Tables["Data"].AsEnumerable().Where(x => x.Field<string>("Name") == "Text Box 1").Select(x => x.Field<string>("Value")).FirstOrDefault();
                textBox2.Text = ds.Tables["Data"].AsEnumerable().Where(x => x.Field<string>("Name") == "Text Box 2").Select(x => x.Field<string>("Value")).FirstOrDefault();
                textBox3.Text = ds.Tables["Data"].AsEnumerable().Where(x => x.Field<string>("Name") == "Text Box 3").Select(x => x.Field<string>("Value")).FirstOrDefault();
                textBox4.Text = ds.Tables["Data"].AsEnumerable().Where(x => x.Field<string>("Name") == "Text Box 4").Select(x => x.Field<string>("Value")).FirstOrDefault();
            }
     
        }
    }
    ​
