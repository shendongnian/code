    public override void NonQueryExecuting(DbCommand command, DbCommandInterceptionContext<int> interceptionContext)
    {
        interceptionContext.SuppressExecution();
        base.NonQueryExecuting(command, interceptionContext);
    }
