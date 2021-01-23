    string name="";
    using (SqlConnection Connection = new SqlConnection("..."))
    {
    using (SqlCommand Command = Connection.CreateCommand())
    {
        Connection.Open();
        Command.CommandText = "SELECT name FROM Users WHERE ID=2";
        name = Command.ExecuteScalar().ToString();
    }
    }
