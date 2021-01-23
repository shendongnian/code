    public class OptionRecompileScope : IDisposable
    {
        private readonly OptionRecompileDbCommandInterceptor interceptor;
        public OptionRecompileScope(DbContext context)
        {
            interceptor = new OptionRecompileDbCommandInterceptor(context);
            DbInterception.Add(interceptor);
        }
        public void Dispose()
        {
            DbInterception.Remove(interceptor);
        }
        private class OptionRecompileDbCommandInterceptor : IDbCommandInterceptor
        {
            private readonly DbContext dbContext;
            internal OptionRecompileDbCommandInterceptor(DbContext dbContext)
            {
                this.dbContext = dbContext;
            }
            public void NonQueryExecuting(DbCommand command, DbCommandInterceptionContext<int> interceptionContext)
            {
            }
            public void NonQueryExecuted(DbCommand command, DbCommandInterceptionContext<int> interceptionContext)
            {
            }
            public void ReaderExecuting(DbCommand command, DbCommandInterceptionContext<DbDataReader> interceptionContext)
            {
                if (ShouldIntercept(command, interceptionContext))
                {
                    AddOptionRecompile(command);
                }
            }
            public void ReaderExecuted(DbCommand command, DbCommandInterceptionContext<DbDataReader> interceptionContext)
            {
            }
            public void ScalarExecuting(DbCommand command, DbCommandInterceptionContext<object> interceptionContext)
            {
                if (ShouldIntercept(command, interceptionContext))
                {
                    AddOptionRecompile(command);
                }
            }
            public void ScalarExecuted(DbCommand command, DbCommandInterceptionContext<object> interceptionContext)
            {
            }
            private static void AddOptionRecompile(IDbCommand command)
            {
                command.CommandText = command.CommandText + " option(recompile)";
            }
            private bool ShouldIntercept(IDbCommand command, DbCommandInterceptionContext interceptionContext)
            {
                return 
                    command.CommandType == CommandType.Text &&
                    command is SqlCommand &&
                    interceptionContext.DbContexts.Any(interceptionDbContext => ReferenceEquals(interceptionDbContext, dbContext));
            }
        }
    }
