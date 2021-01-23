    try {
        sql = new MySqlConnection( {SQL_CONNECTION_STRING} );
        try
        {
            sql.Open();
            sql.Close(); // Close the DB. This block is useful to check whether or not the connection was successfully opened
        }
        catch ( MySqlException e )
        {
            Console.WriteLine( e.Message );
        }
    }
    catch ( MySqlException e )
    {
        Console.Write( e.Message );
    }
