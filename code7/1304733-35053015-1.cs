    protected void btnUser_Click(object sender, EventArgs e)
    { 
            string Name = cmbName.Text, start = string.empty;
    
            SqlConnection myConn = new SqlConnection("Data Source=localhost;" + "Initial Catalog=IBBTS_DB; Integrated Security =SSPI");
    
            SqlCommand retrieveStart_DateCmd = new SqlCommand("SELECT startDate FROM testSet where TS_ID = 121 ;", myConn);
            SqlDataReader reader6 = retrieveStart_DateCmd.ExecuteReader();
                    
            while (reader6.Read())
            {
                  start = (reader6.GetValue(0).ToString());
            }
            reader6.Close();  
    
            DateTime dateTime = DateTime.ParseExact(start, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);//DateTime.ParseExact(start, "dd/MM/yyyy", CultureInfo.InvariantCulture); 
    }
