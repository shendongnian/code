    internal class SampleDBConnectionFactory : IDbConnectionFactory
    {
        /// <summary>
        /// Create SA-DB Connection
        /// </summary>
        /// <param name="nameOrConnectionString">Name of complete connection string</param>
        /// <returns>Instance of an SQL-Connection to a sybase db</returns>
        public System.Data.Common.DbConnection CreateConnection(string nameOrConnectionString)
        {
            SAConnection connection = new SAConnection(ConnectionManager.GetConnectionString(nameOrConnectionString ?? "Default"));
            return connection;
        }
    }
