    public ManageUser GetData(string username)
    {
        var result=new ManageUser();
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
               string query = "SELECT [Username], [EmployeeID] FROM [User] WHERE [Username] = @Username";
               conn.Open();    
               using (SqlCommand cmd = new SqlCommand(query, conn))
               {
                    cmd.Parameters.Add("@Username", SqlDbType.NVarChar);    
                    if (string.IsNullOrEmpty(Username))
                    {
                         cmd.Parameters["@Username"].Value = DBNull.Value;
                    }   
                    else
                    {
                         cmd.Parameters["@Username"].Value = username;
                    }   
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                             while (reader.Read())
                             {                                  
                                    result.Username = reader["Username"].ToString();    
                                    result.EmployeeID = reader["EmployeeID"].ToString();
                              }
                         }    
                         else
                         {
                              reader.Dispose();    
                              cmd.Dispose();
                          }
                     }
               }
               return result;
      }
            }
