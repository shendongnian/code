    public class QueryFactory : IQueryFactory
    {
        private readonly IDictionary<Type, Func<IQuery>> _factoryQueries;
        public QueryFactory(IDictionary<Type, Func<IQuery>> factoryQueries)
        {
            this._factoryQueries = factoryQueries;
        }
        public T ResolveQuery<T>() where T : class, IQuery
        {
            return this._factoryQueries[typeof(T)]() as T;
        }
