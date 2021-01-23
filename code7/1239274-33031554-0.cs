    using (SqlConnection connection = new SqlConnection(ConnectionHelper.Connection("connectionString")))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("...", connection);
                    cmd.CommandText = "SELECT * FROM Customers";
                    cmd.CommandType = CommandType.Text;
    
                    using (SqlDataReader objDataReader = command.ExecuteReader())
                    {
                        if (objDataReader != null)
                        {
                            while (objDataReader.Read())
                            {
                              // To get results...
                              // objDataReader["NameResultParam"];
                            }
                        }
                    }
              }
