    private void getData(string qry)
      {
          int count = 0;
          string strProject = "ARTUR-PC\\SQLEXPRESS"; //Enter your SQL server instance name
          string strDatabase = "Northwind"; //Enter your database name
          string strUserID = "Artlemaks"; // Enter your SQL Server User Name
          string strPassword = "rootUser"; // Enter your SQL Server Password
          string strconn = "data source=" + strProject +
            ";Persist Security Info=false;database=" + strDatabase +
            ";user id=" + strUserID + ";password=" +
            strPassword + ";Connection Timeout = 0";
          //conn = new SqlConnection(strconn);
          using (SqlConnection connection = new SqlConnection(strconn))
          {
              List<CustomerObj> Customers = new List<CustomerObj>();
              connection.Open();
              SqlCommand cmd = connection.CreateCommand();
              cmd.CommandText = qry;
    
              cmd.ExecuteNonQuery();
    
              SqlDataReader reader = cmd.ExecuteReader();
              if (reader.HasRows)
              {
                  while (reader.Read())
                  {
                      CustomerObj row = new CustomerObj();
                      row.custID = reader[0] as int?;
                      row.cmpName = reader[1] as string;
                      row.cntName = reader[2] as string;
                      row.cntTitle = reader[4] as string;
                      row.address = reader[5] as string;
                      row.city = reader[3] as string;
                      row.region = reader[6] as string;
                      row.postalCode = reader[7] as string;
                      row.country = reader[8] as string;
                      row.phone = reader[9] as string;
                      row.fax = reader[10] as string;
                      Console.WriteLine("{0}\t{1}", reader[0],  reader[1]);
    
                      Customers.Add(row);
                  }
    
              }
              reader.Close();
              connection.Close();
    
          }
