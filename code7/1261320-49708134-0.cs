    public class DbTransactions<TEntity> where TEntity : DbEntity, new() {
        public DbTransactions(IDbTransactionsConfiguration configuration) {
            ...
        }
    }
