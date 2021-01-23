    protected async Task<DataTable> OpenQueryAsync(string ConnectionString, string Query)
    {
        using(OdbcConnection connection = new OdbcConnection(ConnectionString))
        {    
            await connection.OpenAsync().ConfigureAwait(false);
    
            using(OdbcCommand command = new OdbcCommand(Query, connection))
            using(DbDataReader dataReader = await command.ExecuteReaderAsync().ConfigureAwait(false))
            {
                DataTable resultData = new DataTable();
                resultData.Load(dataReader);
                return resultData;
            }
        }
    }
