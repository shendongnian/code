    public class cSQL : cDBBaseClass
    {
        private SqlConnection Conn = new SqlConnection();
        public cSQL(string serverName, string dBName, string userName, string password)
            : base(serverName, dBName, userName, password)
        {
            SetConnString();
            SetConn();
        }
        ...
