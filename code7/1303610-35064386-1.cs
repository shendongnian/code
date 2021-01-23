    public class BaseRepo {
        private readonly IConfigurationRoot config;
        public BaseRepo(IConfigurationRoot config) {
            this.config = config;
        }
        public SqlConnection GetOpenConnection() {
            var cs = config.Get<string>("Data:DefaultConnection:ConnectionString");
            var connection = new SqlConnection(cs);
            connection.Open();
            return connection;
        }
    }
