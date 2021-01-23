    public class BaseRepo {
        private readonly IConfiguration config;
        public BaseRepo(IConfiguration config) {
            this.config = config;
        }
        public SqlConnection GetOpenConnection() {
            string cs = config["Data:DefaultConnection:ConnectionString"];
            SqlConnection connection = new SqlConnection(cs);
            connection.Open();
            return connection;
        }
    }
