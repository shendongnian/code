    public class SqlExecutor
    {
      private IIndex<string, IDbConnection> _connections;
      public SqlExecutor(IIndex<string, IDbConnection> connections)
      {
        this._connections = connections;
      }
      public void DoWork(string jobType)
      {
        var connection = this._connections[jobType];
        // do something with the connection
      }
    }
