    public class QueryFactory : IQueryFactory
    {
        private readonly IUnityContainer container;
        public QueryFactory(IUnityContainer container)
        {
            this.container = container;
        }
        public T ResolveQuery<T>()
            where T : class, IQuery
        {
            return this.container.Resolve(typeof(T)) as T;
        }
    }
