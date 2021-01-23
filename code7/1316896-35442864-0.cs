    using System;
    using System.Data;
    using System.Data.OleDb;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
    
                try
                {
                    string fileName = @"Fully Justified path\testbook.xlsx";
                    string ext = ".xlsx";
                    string conString = "";
                    if (ext.ToLower() == ".xls")
                    {
                        conString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + fileName + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=2\""; ;
                    }
                    else if (ext.ToLower() == ".xlsx")
                    {
                        conString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + fileName + ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=2\"";
                    }
    
                    string query = "Select [EmployeeID],[CompanyName], [ContactName],[ContactTitle],[EmployeeAdress],[PostalCode] from [EmployeeData$]";
                    OleDbConnection con = new OleDbConnection(conString);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    OleDbCommand cmd = new OleDbCommand(query, con);
                    OleDbDataAdapter da = new OleDbDataAdapter(cmd);
    
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    da.Dispose();
                    con.Close();
                    con.Dispose();
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        string empID = dr["EmployeeID"].ToString();
    
                        // Update here
                        string empID1 = dr["CompanyName"].ToString();
                        string empID2 = dr["ContactName"].ToString();
                        string empID3 = dr["ContactTitle"].ToString();
                        string empID4 = dr["EmployeeAdress"].ToString();
                        string empID5 = dr["PostalCode"].ToString();
    
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
    }
