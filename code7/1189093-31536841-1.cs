    private void button1_Click(object sender, EventArgs e)
    {
         bool check = true;
         do
         {
              string connectionString = @"Data Source=.\wintouch;Initial Catalog=bbl;User ID=sa;Password=Pa$$w0rd";
              string queryString = string.Empty;
              using (SqlConnection connection = new SqlConnection(connectionString))
              {
                   connection.Open();
                   queryString = "DELETE FROM wgcdoccab WHERE 'tipodoc' ='FSS' and 'FP' ";
                   SqlCommand command = new SqlCommand(queryString, connection);
                   command.Connection.Open();
                   command.ExecuteNonQuery();
               }
               using (SqlConnection connection = new SqlConnection(connectionString))
               {
                    connection.Open();
                    queryString = "SELECT * from wgcdoccab where 'tipodoc' !='FSS' and !='FP'  and contribuinte !='999999990' and  datadoc != CONVERT(varchar(10),(dateadd(dd, -1, getdate())),120)";
    
                    using (SqlCommand command = new SqlCommand(queryString, connection))
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            check = true;
                        }
                        else
                        {
                            check = false;
                        }
                    }
               }          
          } 
          while (check);
    }
