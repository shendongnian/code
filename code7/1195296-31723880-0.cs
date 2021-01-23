    public class LimitInterceptor : IDbCommandTreeInterceptor
    {
        public void TreeCreated(DbCommandTreeInterceptionContext interceptionContext)
        {
            if (interceptionContext.OriginalResult.DataSpace == DataSpace.SSpace)
            {
                var queryCommand = interceptionContext.Result as DbQueryCommandTree;
                if (queryCommand != null)
                {
                    var newQuery = queryCommand.Query.Accept(new LimitVisitor());
                    interceptionContext.Result = new DbQueryCommandTree(
                        queryCommand.MetadataWorkspace,
                        queryCommand.DataSpace,
                        newQuery);
                }
            }
        }
    }
    // rewrite the tree - needs adjustment probably, looks like a very naive implementation (?)
    public class LimitVisitor : DefaultExpressionVisitor
    {
        public override DbExpression Visit(DbScanExpression expression)
        {
            // here we go!
            return DbExpressionBuilder.Limit(expression, 128);
        }
    }
    // will be automatically picked up
    public class MyConfiguration : DbConfiguration
    {
        public MyConfiguration()
        {
            AddInterceptor(new LimitInterceptor());
        }
    }
