    using(var cn = new SqlConnection(strConnectionString))
    using(var InsertCommand = cn.CreateCommand())
    {
        // Set your CommandText property with parameter names.
        // Define your parameter names and it's values. Add them to your command.
        // Open your connection.
        // Execute your query.
    }
