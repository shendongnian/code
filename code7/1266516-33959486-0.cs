    using (SqlConnection connection = new SqlConnection(connectionString))
    {
		connection.Open();
		// Start a local transaction.
		SqlTransaction sqlTran = connection.BeginTransaction();
		// Enlist a command in the current transaction.
		SqlCommand command = connection.CreateCommand();
		command.Transaction = sqlTran;
		try
		{
			// Here is your "business logic"
			command.CommandText = "INSERT INTO tbBusinessLogic VALUES(1)";
			command.ExecuteNonQuery();
			// Check result
			command.CommandText = "Select 1 from tbBusinessLogic";
			var result = (Int32)command.ExecuteScalar();
			CheckResult(result);
			// Rollback the transaction.
			sqlTran.Rollback();
		}
		catch (Exception ex)
		{
            Logger.LogError(ex);
			sqlTran.Rollback();
		}
    }
