    internal class NoLockInterceptor : DbCommandInterceptor
    {
        public static readonly string SET_READ_UNCOMMITED = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
        public static readonly string SET_READ_COMMITED = "SET TRANSACTION ISOLATION LEVEL READ COMMITTED";
    
        public override void ScalarExecuting(DbCommand command, DbCommandInterceptionContext<object> interceptionContext)
        {
            if (!interceptionContext.DbContexts.OfType<IFortisDataStoreNoLockContext>().Any())
            {
                return;
            }
    
            ExecutingBase(command);
        }
    
        public override void ReaderExecuting(DbCommand command, DbCommandInterceptionContext<DbDataReader> interceptionContext)
        {
            if (!interceptionContext.DbContexts.OfType<IFortisDataStoreNoLockContext>().Any())
            {
                return;
            }
    
            ExecutingBase(command);
        }
    
        private static void ExecutingBase(DbCommand command)
        {
            var text = command.CommandText;
            command.CommandText = $"{SET_READ_UNCOMMITED} {Environment.NewLine} {text} {Environment.NewLine} {SET_READ_COMMITED}";
        }
    }
