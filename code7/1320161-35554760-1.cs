    string GenerateConnectionString()
    {
        return SharedDatabase.SQLBase.DBconnection + "multipleactiveresultsets=True;";
    }
    public class MyUnitOfWork
    {
        SqlConnection _commonConnection;
        DbTransaction _commonTransaction;
        // Generic function to create DBContext object based on T supplied.
        public T GetDbContext<T>()
        {
            if (_commonConnection == null)
            {
                // generates a generic connection string 
                _commonConnection = new SqlConnection(DbContextBase.GenerateConnectionString());
    
                _commonConnection.Open();
    
                _commonTransaction = _connection.BeginTransaction(IsolationLevel.Snapshot);
            }
            MetadataWorkspace workspace = new MetadataWorkspace(
              string.Format("res://*/{0}.csdl|res://*/{0}.ssdl|res://*/{0}.msl;", typeof(T).Name).Split('|'), 
              new Assembly[] { Assembly.GetExecutingAssembly() });
            var connection = new EntityConnection(workspace, _commonConnection);
            T myContextObject = (T)Activator.CreateInstance(typeof(T), new object[] { connection });
            myContextObject.Database.UseTransaction(_commonTransaction);
            return myContextObject;
        }
    }
