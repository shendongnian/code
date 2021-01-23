    public string SendUserData(string Name, string Password, string Email)
    {
        using(SqlCeConnection conn = new SqlCeConnection("....."))
        using(SqlCeCommand cmd = new SqlCeCommand(@"INSERT INTO User (Username, Password, Email) 
                                     VALUES (@name, @pass, @email)" , conn );
        {
            conn.Open();
            cmd.Parameters.AddWithValue("@name",  Name);
            cmd.Parameters.AddWithValue("@pass",  Password);
            cmd.Parameters.AddWithValue("@email",  EMail);
            cmd.ExecuteNonQuery();  // <- This line inserts the record in the database
        }
        // This line probably is not needed
        return cmd.CommandText;
    }
