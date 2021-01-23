    class Query<T> : IQueryable<T>
    {
        private IQueryProvider provider;
        private Expression expression;
        public Query(IQueryProvider provider, Expression expression)
        {
            this.provider = provider;
            this.expression = expression;
        }
        public IEnumerator<T> GetEnumerator()
        {
            return ((IEnumerable<T>)this.Provider.Execute(this.Expression)).GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this.Provider.Execute(this.Expression)).GetEnumerator();
        }
        public Type ElementType
        {
            get { return typeof(T); }
        }
        public Expression Expression
        {
            get { return expression; }
        }
        public IQueryProvider Provider
        {
            get { return provider; }
        }
    }
    public static IQueryable<T> Simplify<T>(this IQueryable<T> query)
    {
        return new Query<T>(query.Provider, Evaluator.PartialEval(query.Expression));
    }
