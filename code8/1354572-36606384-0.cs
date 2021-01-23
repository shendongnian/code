        public static IQueryable<T> WhereIn<T, TKey>(this IQueryable<T> source, Expression<Func<T, TKey>> selector, IEnumerable<TKey> keyCollection)
        {
            if (selector == null) throw new ArgumentNullException("Null selector");
            if (keyCollection == null) throw new ArgumentNullException("Null collection");
            //if no items in collection, no results
            if (!keyCollection.Any()) return source.Where(t => false);
            //assemble expression
            var p = selector.Parameters.Single();
            var equals = keyCollection.Select(value => (Expression)Expression.Equal(selector.Body, Expression.Constant(value, typeof(TKey))));
            var body = equals.Aggregate((accumulate, equal) => Expression.Or(accumulate, equal));
            //return expression
            return source.Where(Expression.Lambda<Func<T, bool>>(body, p));
        }
