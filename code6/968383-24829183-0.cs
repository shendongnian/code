    using(var conn = new MySqlConnection(connectionString)
    {
        conn.Open();
        using(MySqlCommand cmd = new MySqlCommand())
        {
            cmd.Connection = conn;
            cmd.CommandText = "SELECT Initials FROM [Fixers and Testers]  WHERE [Status] ='C'";
            MySqlDataReader reader = cmd.ExecuteReader();
            while(reader.Read())
            {
                // initials is a List<String> previously defined (Assuming strings)
                initials.Add(String.Format("{0}", reader[0]));
            }
        }
        conn.Close();
    }
    
