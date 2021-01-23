    public class OptionHintDbCommandInterceptor: IDbCommandInterceptor
    {
        public void NonQueryExecuting(DbCommand command, DbCommandInterceptionContext<Int32> interceptionContext)
        {
        }
        public void NonQueryExecuted(DbCommand command, DbCommandInterceptionContext<int> interceptionContext)
        {
        }
        public void ReaderExecuted(DbCommand command, DbCommandInterceptionContext<DbDataReader> interceptionContext)
        {
        }
        public void ReaderExecuting(DbCommand command, DbCommandInterceptionContext<DbDataReader> interceptionContext)
        {
            var context = interceptionContext.DbContexts.FirstOrDefault();
            if (context is IQueryHintable)
            {
                var hints = (IQueryHintable)context;
                if (hints.HintWithRecompile)
                {
                    addRecompileQueryHint(command);
                }
            }
        }
        public void ScalarExecuted(DbCommand command, DbCommandInterceptionContext<object> interceptionContext)
        {
        }
        public void ScalarExecuting(DbCommand command, DbCommandInterceptionContext<object> interceptionContext)
        {
            var context = interceptionContext.DbContexts.FirstOrDefault();
            if (context is IQueryHintable)
            {
                var hints = (IQueryHintable)context;
                if (hints.HintWithRecompile)
                {
                    addRecompileQueryHint(command);
                }
            }
        }
        private static void addRecompileQueryHint(IDbCommand command)
        {
            if (command.CommandType != CommandType.Text || !(command is SqlCommand))
                return;
            if (command.CommandText.StartsWith("select", StringComparison.OrdinalIgnoreCase) && !command.CommandText.Contains("option(recompile)"))
            {
                command.CommandText = command.CommandText + " option(recompile)";
            }
        }
    }
