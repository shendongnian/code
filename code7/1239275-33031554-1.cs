    using (SqlConnection connection = new SqlConnection("connectionString"))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand();
                    command.CommandText = "SELECT * FROM Customers";
                    command.CommandType = CommandType.Text;
    
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
