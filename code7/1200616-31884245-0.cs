    using (var connection = new SqlConnection(_connectionString))
    {
        connection.Open();
        using (SqlTransaction trans = connection.BeginTransaction("PricesCleanup"))
        using (var command = new SqlCommand("", connection, trans))
        {
            //Reseed the identity to 0.
            command.CommandText = "DBCC CHECKIDENT (Prices, RESEED, 0)";
            command.ExecuteNonQuery();
            //Roll the identity forward till it finds the last used number.
            command.CommandText = "DBCC CHECKIDENT (Prices, RESEED)";
            command.ExecuteNonQuery();
            trans.Commit();
        }
    }
