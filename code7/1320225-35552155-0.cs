    public interface IDbConnection
    {
        IDbCommand CreateCommand();
        // other methods
    }
    public class MyOleDbConnection : IDbConnection
    {
        private OleDbConnection conn;
        public MyOleDbConnection()
        {
            // initialize "conn" here
        }
        public IDbCommand CreateCommand()
        {
            return conn.CreateCommand();
        }
        // other pass-thru methods
    }
