    public static bool searchusername(string username)
    {
        connectionString = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
        using(SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();
    
            bool exists = false;
    
            using (SqlCommand comm = new SqlCommand("select count(*) from Member where UserName = @UserName", conn))
            {
                comm.Parameters.AddWithValue("@username", username);
                exists = (int)comm.ExecuteScalar() > 0;
            }
            return exists;
        }
