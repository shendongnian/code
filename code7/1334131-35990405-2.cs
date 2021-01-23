    public static async Task<DataTable> GetDataTableAsync(string connectionString, SqlCommand command)
    {
        using (var connection = new SqlConnection(connectionString))
        {
            command.Connection = connection;
            await connection.OpenAsync();
            using (var dataReader = await command.ExecuteReaderAsync())
            {
                var dataTable = new DataTable();
                dataTable.Load(dataReader);
                return dataTable;
            }
        }
    }
