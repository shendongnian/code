    public class OracleDBManager
    {
        private OracleConnection _con;
        private const string connectionString = "User Id={0};Password={1};Data Source=MyDataSource;";
		private const string OracleDBUser = "exampleUser";
		private const string OracleDBPassword = "examplePassword";
        public OracleDBManager()
        {
            InitializeDBConnection();
        }
        ~OracleDBManager()
        {
            if (_con != null)
            {
                _con.Close();
                _con.Dispose();
                _con = null;
            }
        }
        private void InitializeDBConnection()
        {
                _con = new OracleConnection();
                _con.ConnectionString = string.Format(connectionString, OracleDBUser, OracleDBPassword);
                _con.Open();
        }
    }
