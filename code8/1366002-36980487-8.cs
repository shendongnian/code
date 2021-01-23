    public class RetryInterceptor : DbCommandInterceptor {
        public override void NonQueryExecuting(DbCommand command, DbCommandInterceptionContext<int> interceptionContext) {
            interceptionContext.Result = ((SqlCommand)command).ExecuteNonQueryWithRetry();
        }
        public override void ReaderExecuting(DbCommand command, DbCommandInterceptionContext<DbDataReader> interceptionContext) {
            interceptionContext.Result = ((SqlCommand)command).ExecuteReaderWithRetry();
        }
        public override void ScalarExecuting(DbCommand command, DbCommandInterceptionContext<object> interceptionContext) {
            interceptionContext.Result = ((SqlCommand)command).ExecuteScalarWithRetry();
        }               
    }
