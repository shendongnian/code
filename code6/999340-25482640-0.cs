    public class DbMigrationsInterceptingConfiguration<TContext> : DbMigrationsConfiguration<TContext> 
        where TContext : DbContext
    {
        public DbMigrationsInterceptingConfiguration() {
            BeforeFirstConnectionInterceptor.InterceptNext();
        }
        protected override void Seed(TContext context) {
            Console.WriteLine("After All!");
        }
    }
    internal class BeforeFirstConnectionInterceptor : IDbConnectionInterceptor {
        public static void InterceptNext() {
            DbInterception.Add(new BeforeFirstConnectionInterceptor());
        }
        public void Opened(DbConnection connection, DbConnectionInterceptionContext interceptionContext) {
            // NOT thread safe
            Console.WriteLine("Before All!");
            DbInterception.Remove(this);
        }
        // ... empty implementation of other methods in IDbConnectionInterceptor
     }
