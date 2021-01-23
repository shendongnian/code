    foreach(string connectionString in Servers)
    {
        using (var context = new DbContext(connectionString))
        {
          //Query code
        }
    }
