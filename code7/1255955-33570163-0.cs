    public void DisableAllForeignKeys()
    {
        using (var connection = new SqlConnection(connectionString))
        {
            var command = new SqlCommand($"EXEC sp_msforeachtable \"ALTER TABLE ? NOCHECK CONSTRAINT all\"", connection);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
    
    public void EnableAllForeignKeys()
    {
        using (var connection = new SqlConnection(connectionString))
        {
            var command = new SqlCommand($"EXEC sp_msforeachtable \"ALTER TABLE ? WITH CHECK CHECK CONSTRAINT all\"", connection);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
