    public interface IOracleQueryable<T> : IQueryable<T> { }
    
    public static class OracleQueryExtensions
    {
        public static IOracleQueryable<TSource> AsOracleQueryable<TSource>(
                this IQueryable<TSource> source) => new OracleQueryable<TSource>(source);
        
        public static IOracleQueryable<TSource> Where<TSource>(
                this IOracleQueryable<TSource> source, Expression<Func<TSource, bool>> predicate) =>
            Queryable.Where(source, Replace(predicate)).AsOracleQueryable();
            
        private static Expression<TDelegate> Replace<TDelegate>(Expression<TDelegate> expr) =>
            OracleEFQueryUtils.ReplaceVariablesWithConstants<TDelegate>(expr);
        
        private class OracleQueryable<TSource> : IOracleQueryable<TSource>
        {
            public OracleQueryable(IQueryable<TSource> source) { Source = source; }
            private IQueryable<TSource> Source { get; }
            
            public Expression Expression => Source.Expression;
            public IQueryProvider Provider => Source.Provider;
            public Type ElementType => Source.ElementType;
            public IEnumerator<TSource> GetEnumerator() => Source.GetEnumerator();
            System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() =>
                GetEnumerator();
        }
    }
