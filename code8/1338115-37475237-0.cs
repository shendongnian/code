        MySqlConnection MYSQLCON;
        MySqlDataAdapter daDataAdapter;
        MySqlCommand MYSQLCmd;
        public MYSQLDataAccess()
        {
            ConnectionStrinG = getMySqlConnectionString();
            MYSQLCON = new MySqlConnection(ConnectionStrinG);
        }
        public string getMySqlConnectionString()
        {
            string CString = ConfigurationManager.AppSettings["MyCString"].ToString();  // Connection string from web.config
            string ConStr = ConfigurationManager.ConnectionStrings[CString].ToString();
            return ConStr;
        }
    
