    // not ideal, but let's hold the connection string in a backing field
    // would be better if the connection string could be passed in at runtime
    // instead of the data access layer needing direct access to the config file
    private static readonly string ConnString = ConfigurationManager.ConnectionStrings["TopJobdb"].ConnectionString;
    
    public static void InsertLogin(Registration u)
    {
        using (var conn = new SqlConnection(ConnString))
        using (var cmd = new SqlCommand()
        {
            cmd.Connection = conn;
            cmd.CommandText = "INSERT INTO topJobUser(username, email, password) VALUES (@username, @email, @password)";
            
            // be sure to set the size value correctly
            cmd.Parameters.Add("@username", SqlDbType.VarChar, 100).Value = u.UserName;
            cmd.Parameters.Add("@email", SqlDbType.VarChar, 100).Value = u.Email;
            cmd.Parameters.Add("@password", SqlDbType.VarChar, 100).Value = u.password;
            
            conn.Open();
            
            cmd.ExecuteNonQuery();
        }
    }
