        using (connection)
        {
            // Configure the SqlCommand and SqlParameter.
            SqlCommand insertCommand = new SqlCommand(
                "usp_InsertTableRecords", connection);
            insertCommand.CommandType = CommandType.StoredProcedure;
            SqlParameter tvpParam = insertCommand.Parameters.AddWithValue(
                "@tvpNewTableRecords", newTableRecords);
            tvpParam.SqlDbType = SqlDbType.Structured;
            // Execute the command.
            insertCommand.ExecuteNonQuery();
        }
