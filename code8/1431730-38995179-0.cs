    public class InsightDatabase : IInsightDatabase
    {
        private readonly IDbConnection _connection;
        public InsightDatabase(IDbConnection connection)
        {
            _connection = connection;
        }
        public async Task<T> QueryAsync<T>(string sql, object parameters, IQueryReader<T> returns, CommandType commandType = CommandType.StoredProcedure, CommandBehavior commandBehavior = CommandBehavior.Default, int? commandTimeout = default(int?), IDbTransaction transaction = null, CancellationToken? cancellationToken = default(CancellationToken?), object outputParameters = null)
        {
            return await _connection.QueryAsync(sql, parameters, returns, commandType, commandBehavior, commandTimeout, transaction, cancellationToken, outputParameters);
        }
    }
