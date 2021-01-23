    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    namespace WindowsFormsApplication8
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
            public List<typeStruct> lstType = new List<typeStruct>();
            private void button1_Click(object sender, EventArgs e)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("field1", typeof(int));
                dt.Columns.Add("field2", typeof(long));
                dt.Columns.Add("field3", typeof(long));
                dt.Columns.Add("field4", typeof(long));
                dt.Columns.Add("field5", typeof(long));
                dt.Columns.Add("field6", typeof(long));
                dt.Columns.Add("field7", typeof(long));
                dt.Columns.Add("field8", typeof(int));
                dt.Columns.Add("field9", typeof(int));
                dt.Columns.Add("field10", typeof(string));
                foreach (typeStruct ts in lstType)
                {
                    dt.Rows.Add(ts.all);
                }
                dataGridView1.DataSource = dt;
            }
        }
        public class typeStruct
        {
            public int field1 { get; set; }
            public long field2 { get; set; }
            public long field3 { get; set; }
            public long field4 { get; set; }
            public long field5 { get; set; }
            public long field6 { get; set; }
            public long field7 { get; set; }
            public int field8 { get; set; }
            public int field9 { get; set; }
            public string[] field10 { get; set; }
            public object[] all
            {
                get { return new object[] { field1, field2, field3, field4, field5, field6, field7, field8, field9, string.Join(",", field10) }; }
                set {
                    field1 = (int)value[0];
                    field2 = (long)value[1];
                    field3 = (long)value[2];
                    field4 = (long)value[3];
                    field5 = (long)value[4];
                    field6 = (long)value[5];
                    field7 = (long)value[6];
                    field8 = (int)value[7];
                    field9 = (int)value[8];
                    field10 = ((string)(value[9])).Split(new char[] {','});
                }
            }
               
        }
    }
