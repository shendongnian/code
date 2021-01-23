    public class Tx
    {     
    		public DbConnectionExtra _connection { get; set; } // class which has DbTransaction and DbConnection combined 
    
            public T UseTx<T>(Func<T> fnToCall)
            {          
                try
                {
                    _connection.BeginTransaction();
    							
                    var result = fnToCall();
    
                   _connection._transaction.Commit();
    			   _connection._transaction.Dispose();
    
                    return result;
                }
                catch
                {
                   _connection._transaction.Rollback();
    				_connection._transaction.Dispose();
                    
                    throw;
                }
            }
    }
