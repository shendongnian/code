    public class OracleDBManager
    {
        #region Fields
        private OracleConnection _con;
        private const string connectionString = "User Id={0};Password={1};Data Source=MyDataSource;";
		pricate const string OracleDBUser = "exampleUser";
		pricate const string OracleDBPassword = "examplePassword";
        #endregion Fields
        #region Constructor
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
        #endregion Constructor
        #region Class Methods
        private void InitializeDBConnection()
        {
                _con = new OracleConnection();
                _con.ConnectionString = string.Format(connectionString, OracleDBUser, OracleDBPassword);
                _con.Open();
        }
        #endregion Class Methods
    }
