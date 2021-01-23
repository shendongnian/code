    using(var conn = new SqlConnection(conString))
    {
        using(var cmd = new SqlCommand(sql, conn)
        {
            conn.Open();
            ... use the command
        }
    }
