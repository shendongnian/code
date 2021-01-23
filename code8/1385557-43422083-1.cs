    public class OracleConnectionFactory: IDbConnectionFactory {
        public IDbConnection CreateConnection() {
            return new OracleConnection("connection string");
        }
    }
