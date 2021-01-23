    private void ReadMyData()
    {
      var builder = new OleDbConnectionStringBuilder();
      builder.Provider = "VFPOLEDB";
      builder.DataSource = @"C:\Program Files (x86)\Microsoft Visual FoxPro 9\Samples\Northwind";
    
      string sql = "Select * from Customers where Country like ?";
    
      using (OleDbConnection con = new OleDbConnection(builder.ConnectionString))
      using (OleDbCommand cmd = new OleDbCommand(sql, con))
      {
        cmd.Parameters.AddWithValue("@country", "USA");
        try
        {
          con.Open();
          var reader = cmd.ExecuteReader();
          while (reader.Read())
          {
            Debug.WriteLine("{0}, {1}",
              reader["CustomerId"],
              reader["CompanyName"]);
          }
          con.Close();
    
        }
        catch (Exception ex)
        {
          Debug.Write("Can not open connection ! " + ex);
        }
      }
    }
