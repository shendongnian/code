    public class DbConnectionCheckInterceptor : DbCommandInterceptor
        {
            public override void NonQueryExecuting(DbCommand command, DbCommandInterceptionContext<int> interceptionContext)
            {
                 //check connection
            }
    
            public override void ScalarExecuting(DbCommand command, DbCommandInterceptionContext<object> interceptionContext)
            {
                 //check connection
            }
    
            public override void ReaderExecuting(DbCommand command, DbCommandInterceptionContext<DbDataReader> interceptionContext)
            {
                 //check connection
            }
        }
