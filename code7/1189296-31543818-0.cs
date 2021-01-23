    public static Tuple<string,string> searchEmail(string email)
    {
        string userName = "";
        connectionString = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
        SqlConnection conn = new SqlConnection(connectionString);
        {
            conn.Open();              
    
            using (SqlCommand comm = new SqlCommand("select UserName from Member where email = @email", conn))
            {
                SqlDataReader reader;
                comm.Parameters.AddWithValue("@email", email);
                reader = comm.ExecuteReader();
                if (reader.HasRows)
                {
                  while (reader.Read())
                  {                                
                     userName = reader.GetString(0);
                  }
                }
            }          
        }
         conn.Close();
         return new Tuple<string,string>(email,userName);
    }
