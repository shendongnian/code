    using System.Data;
    using System.Data.OleDb;
    using System.Text;
    using System.Xml;
    
    namespace Example
    {
        /// <summary>
        /// Create instance of this class,
        /// pass in file name and if excel sheet has headers e.g. YES or NO
        /// execute Work method, is currently incomplete
        /// </summary>
        public class StackOverFlowDemo
        {
            private string CreateConnectionString(string FileName, string Header)
            {
                OleDbConnectionStringBuilder Builder = new OleDbConnectionStringBuilder();
                if (System.IO.Path.GetExtension(FileName).ToUpper() == ".XLS")
                {
                    Builder.Provider = "Microsoft.Jet.OLEDB.4.0";
                    Builder.Add("Extended Properties", string.Format("Excel 8.0;IMEX=2;HDR={0};", Header));
                }
                else
                {
                    Builder.Provider = "Microsoft.ACE.OLEDB.12.0";
                    Builder.Add("Extended Properties", string.Format("Excel 12.0;IMEX=2;HDR={0};", Header));
                }
    
                Builder.DataSource = FileName;
    
                return Builder.ConnectionString;
            }
            public string ConnectionString { get; set; }
            public StackOverFlowDemo(string FileName, string Header)
            {
                ExcelTable = new DataTable();
                CreateConnectionString(FileName, Header);
                LoadData();
            }
            public DataTable ExcelTable { get; set; }
            public void LoadData()
            {
                using (OleDbConnection cn = new OleDbConnection { ConnectionString = ConnectionString })
                {
                    cn.Open();
    
                    using (OleDbCommand cmd = new OleDbCommand { CommandText = "SELECT * FROM [Sheet 1$]", Connection = cn })
                    {
                        OleDbDataReader dr = cmd.ExecuteReader();
                        ExcelTable.Load(dr);
                    }
                }
            }
            public void Work()
            {
                StringBuilder StrPubBldg = new System.Text.StringBuilder();
                XmlWriter xw = XmlWriter.Create(StrPubBldg);
                // continue logic
            }
        }
    }
