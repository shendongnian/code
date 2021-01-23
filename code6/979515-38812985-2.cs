    public override void NonQueryExecuting(DbCommand command, DbCommandInterceptionContext<int> interceptionContext)
    {
        interceptionContext.Result = -1;
        base.NonQueryExecuting(command, interceptionContext);
    }
