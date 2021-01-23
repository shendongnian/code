    protected void btnUser_Click(object sender, EventArgs e)
        {
            {
                string Name = cmbName.Text;
                DateTime start = default(DateTime);
    
                SqlConnection myConn = new SqlConnection("Data Source=localhost;" + "Initial Catalog=IBBTS_DB; Integrated Security =SSPI");
    
                    SqlCommand retrieveStart_DateCmd = new SqlCommand("SELECT startDate FROM testSet where TS_ID = 121 ;", myConn);
                    SqlDataReader reader6 = retrieveStart_DateCmd.ExecuteReader();
                    while (reader6.Read())
                    {
                        start = (DateTime)reader6[0];
                    }
                    reader6.Close();  
                    string myFormattedString = start.ToString("dd/MM/yyyy");
             }
        }
