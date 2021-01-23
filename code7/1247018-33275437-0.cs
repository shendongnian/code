    public string GetPassword(string username)
    {
         string query = "SELECT Password FROM dbo.Login WHERE username=@UN";
    
         using(SqlConnection conn = new SqlConnection(connectionString))
         using(SqlCommand cmd = new SqlCommand(query))
         {
              cmd.Parameters.AddWithValue("@UN", tb_Username);
              conn.Open();
              return (string)cmd.ExecuteScalar();
         }
    }
