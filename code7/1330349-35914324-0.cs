    public class SqlImpersonatedConnection : DbConnection
    {
        private readonly SqlConnection _connection; //SqlImpersonatedConnection calls into _connection, doing impersonation where required
        private readonly string _domain;
        private readonly string _username;
        private readonly string _password;
        private IImpersonationContext _impersonationContext;
        public SqlImpersonatedConnection(string connectionString, string domain, string username, string password)  
        {
            _domain = domain;
            _username = username;
            _password = password;
            _connection = new SqlConnection(connectionString);
        }
        
        //more stuff
     }
    public class SqlImpersonatedCommand : DbCommand
    {
        private readonly SqlCommand _command; //SqlImpersonatedCommand just calls into command
        public SqlImpersonatedCommand(string commandText)
        {
            _command = new SqlCommand(commandText);
        }
    }
