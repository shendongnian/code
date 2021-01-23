    public class DbTransactions<TEntity> where TEntity : DbEntity, new()
    {
      private readonly Query _query;
    
      public DbTransactions(DatabaseConnectionInfo dbConnInfo)
      {
        _query = new Query(dbConnInfo.ConnectionString);
      }
    
      public TEntity GetById(long id) { ... }
    }
