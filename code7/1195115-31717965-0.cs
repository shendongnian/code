    using(var con = new OleDbConnection())
    using(var com = con.CreateCommand())
    {
       // Set your CommandText property.
       // Add your parameters with Add method in the same order that you defined.
       // Open your connection.
       // Execute your query.
    }
