    using System;
    using System.Data;
    using System.Data.OleDb;
    using System.IO;
    using System.Windows.Forms;
    
    namespace Example_C1
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            public string ConnectionString(string FileName, string Header)
            {
                OleDbConnectionStringBuilder Builder = new OleDbConnectionStringBuilder();
                if (System.IO.Path.GetExtension(FileName).ToUpper() == ".XLS")
                {
                    Builder.Provider = "Microsoft.Jet.OLEDB.4.0";
                    Builder.Add("Extended Properties", string.Format("Excel 8.0;IMEX=1;HDR={0};", Header));
                }
                else
                {
                    Builder.Provider = "Microsoft.ACE.OLEDB.12.0";
                    Builder.Add("Extended Properties", string.Format("Excel 12.0;IMEX=1;HDR={0};", Header));
                }
    
                Builder.DataSource = FileName;
    
                return Builder.ConnectionString;
            }
    
            public DataTable LoadData(string FileName, string SheetName, DateTime TheDate)
            {
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                DataTable dt = new DataTable();
    
                using (OleDbConnection cn = new OleDbConnection { ConnectionString = ConnectionString(FileName, "Yes") })
                {
                    cn.Open();
                    using (OleDbCommand cmd = new OleDbCommand { CommandText = 
                        @"
                            SELECT 
                                [Dates], 
                                [Office Plan] As OfficePlan 
                            FROM [Sheet2$] 
                            WHERE [Dates] = #8/21/2013#", Connection = cn })
                    {
                        OleDbDataReader dr = cmd.ExecuteReader();
                        dt.Load(dr);
                    }
    
                    return dt;
                }
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                DateTime TheDate = new DateTime(2010, 8, 21);
                DataGridView1.DataSource = LoadData(
                    Path.Combine(Application.StartupPath, "WS1.xlsx"), "Sheet2", TheDate).DefaultView;
                DataGridView1.Columns["OfficePlan"].HeaderText = "Office Plan";
            }
        }
    }
