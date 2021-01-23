    public class ExistRepository : Repository
    {
        public ExistRepository(string connectionString) : base(connectionString)
        {
        }
        public bool Exists(string tableName, string fieldName, object value)
        {
            //just check if value exists
            var query = string.Format("SELECT TOP 1 1 FROM {0} l WHERE {1} = @value", tableName, fieldName);
            var parameters = new DynamicParameters();
            parameters.Add("@value", value);
             
            //i use dapper here, and "GetConnection" is inherited from base repository
            var result = GetConnection(c => c.ExecuteScalar<int>(query, parameters, commandType: CommandType.Text)) > 0;
            return result;
        }
    }
