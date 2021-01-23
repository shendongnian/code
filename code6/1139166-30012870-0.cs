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
            const string FILENAME = @"c:\temp\test.xml";
            AutoCount autoCount = new AutoCount();
            public Form1()
            {
                InitializeComponent();
                autoCount.ds.WriteXml(FILENAME, XmlWriteMode.WriteSchema);
                dataGridView1.DataSource = autoCount.ds.Tables["AutoCount"];
                dataGridView2.DataSource = autoCount.ds.Tables["Sales"];
            }
            public class AutoCount
            {
                public DataSet ds {get; set;} 
                public AutoCount()
                {
                    ds = new DataSet();
                    DataTable autoCount = new DataTable("AutoCount");
                    ds.Tables.Add(autoCount);
                    DataTable sales = new DataTable("Sales");
                    ds.Tables.Add(sales);
                    autoCount.Columns.Add("Product", typeof(string));
                    autoCount.Columns.Add("Version", typeof(string));
                    autoCount.Columns.Add("CreatedApplication", typeof(string));
                    autoCount.Columns.Add("CreatedBy", typeof(string));
                    autoCount.Rows.Add(new string[] {
                        "AutoCount Accounting",
                        "1.5",
                        "BApp",
                        "Business Solutions"
                    });
                    sales.Columns.Add("DocNo", typeof(string));
                    sales.Columns.Add("Item", typeof(string));
                    sales.Columns.Add("Qty", typeof(int));
                    sales.Columns.Add("Price", typeof(double));
                    sales.Rows.Add(new object[] {
                        "S0001",
                        "XXX",
                        2,
                        6.00
                    });
                    sales.Rows.Add(new object[] {
                        "S0002",
                        "YYY",
                        3,
                        50.00
                    });
                }
            }
        }
    }
    ​
