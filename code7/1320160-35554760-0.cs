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
    
                _connection.Open();
    
                _commonTransaction = _connection.BeginTransaction(IsolationLevel.Snapshot);
            }
            T myContextObject = (T)Activator.CreateInstance(typeof(T), new object[] { _connection, false });
            myContextObject.Database.UseTransaction(_commonTransaction);
            return myContextObject;
        }
    }
