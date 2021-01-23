    public interface IQueryHandlerFactory
    { 
        IQueryHandler<TQuery, TQueryResult>()
            where TQuery : IQuery, TQueryResult : IQueryResult;
    }
    public class QueryHandlerFactory : IQueryHandlerFactory
    {
        private readonly IResolutionRoot resolutionRoot;
        public QueryHandlerFactory(IResolutionRoot resolutionRoot)
        {
            this.resolutionRoot = resolutionRoot;
        }
        
        IQueryHandler<TQuery, TQueryResult>()
            where TQuery : IQuery, TQueryResult : IQueryResult
        {
            var queryHandlerType = typeof(IQueryHandler<TQuery,TQueryResult>);
            return (IQueryHandler<TQuery, TQueryResult>)kernel.Get(queryHandlerType);
        }
    }
