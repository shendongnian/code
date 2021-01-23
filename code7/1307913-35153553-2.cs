    using(var SQLconn = new MySqlConnection(conString))
    using(var cmd = SQLconn.CreateCommand())
    {
        // Set your CommandText property.
        using(var dRead = cmd.ExecuteReader())
        {
            // Do your stuff
        }
    }
