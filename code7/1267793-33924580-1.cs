    public class DataQuery
    {
        private readonly string _connectionString;
        public DataQuery(string connectionString)
        {
            _connectionString = connectionString;
        }
        public IEnumerable<T> GetList<T>(string procedure,
            Func<IDataRecord, T> entityCreator,
            params SqlParameter[] commandParameters
            )
        {
            var result = new List<T>();
            using (var connection = new SqlConnection(_connectionString))
            using (var command = CreateCommand(procedure, connection, commandParameters))
            using (var reader = command.ExecuteReader())
            {
                result.Add(entityCreator(reader));
            }
            return result;
        }
        private static DbCommand CreateCommand(string procedure, 
            SqlConnection connection, SqlParameter[] commandParameters)
        {
            var command = new SqlCommand(procedure, connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.AddRange(commandParameters);
            return command;
        }
    }
