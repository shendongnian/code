                    // context.Database.Create();  // TODO: remove this and make delete the schema and its objects
                    var HandleNoCreateDatabase = new HandleNoCreateDatabase();
                    DbInterception.Add(HandleNoCreateDatabase);
                    context.Database.Create();
                    DbInterception.Remove(HandleNoCreateDatabase);
...
    public class HandleNoCreateDatabase : IDbCommandInterceptor
    {
        public void NonQueryExecuting(
            DbCommand command, DbCommandInterceptionContext<int> interceptionContext)
        {
            LogIfNonAsync(command, interceptionContext);
        }
        public void NonQueryExecuted(
            DbCommand command, DbCommandInterceptionContext<int> interceptionContext)
        {
            LogIfError(command, interceptionContext);
        }
        public void ReaderExecuting(
            DbCommand command, DbCommandInterceptionContext<DbDataReader> interceptionContext)
        {
            LogIfNonAsync(command, interceptionContext);
        }
        public void ReaderExecuted(
            DbCommand command, DbCommandInterceptionContext<DbDataReader> interceptionContext)
        {
            LogIfError(command, interceptionContext);
        }
        public void ScalarExecuting(
            DbCommand command, DbCommandInterceptionContext<object> interceptionContext)
        {
            LogIfNonAsync(command, interceptionContext);
        }
        public void ScalarExecuted(
            DbCommand command, DbCommandInterceptionContext<object> interceptionContext)
        {
            LogIfError(command, interceptionContext);
        }
        private void LogIfNonAsync<TResult>(
            DbCommand command, DbCommandInterceptionContext<TResult> interceptionContext)
        {
            if (!interceptionContext.IsAsync)
            {
                Debug.Print("Non-async command used: {0}", command.CommandText);
                // If EF is checking for database existance, tell it that it does not exist
                if (command.CommandText.ToLower().Contains("select count(*) from sys.databases where [name]="))
                {
                    command.CommandText = "SELECT 0";
                }
                // If EF is creating the database, disable the create request
                if (command.CommandText.ToLower().Contains("create database"))
                {
                    command.CommandText = "SELECT 0";
                }
            }
        }
        private void LogIfError<TResult>(
            DbCommand command, DbCommandInterceptionContext<TResult> interceptionContext)
        {
            if (interceptionContext.Exception != null)
            {
                Debug.Print("Command {0} failed with exception {1}",
                    command.CommandText, interceptionContext.Exception);
            }
        }
    }
