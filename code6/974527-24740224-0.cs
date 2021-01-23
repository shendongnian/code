    using(MySqlConnection conn = new MySqlConnection(connStr))
    {
        conn.Open();
        using(MySqlTransaction tr = conn.BeginTransaction())
        {
            ...
            // MySqlCommand code  goes here
            ...
            tr.Commit();
       }
    }
