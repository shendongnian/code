        var sqlQuery = "delete from table";
        using (var connection = new SqlConnection(ConnectionString))
        {
            await connection.OpenAsync();
            using (var tran = connection.BeginTransaction())
			using (var command = new SqlCommand(sqlQuery, connection, tran))
			{
				try {
					await command.ExecuteNonQueryAsync();
				} catch {
					tran.Rollback();
					throw;
				}
				tran.Commit();
			}
        }
