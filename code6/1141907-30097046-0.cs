    using (var conn = new SqlConnection("..."))
    {
        conn.Open();
        using (var cmd = conn.CreateCommand())
        {
            cmd.CommandText = "Command text.....";
            using (var reader = cmd.ExecuteReader())
            {
               ....
            }
        }
    }
