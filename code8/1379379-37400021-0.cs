    private async Task<T> CallDatabaseAsync<T>(Func<SqlConnection, Task<T>> execAsync)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            connection.Open();
            return await execAsync(connection).ConfigureAwait(false);
        }
    }
