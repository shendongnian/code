        public IQueryable<T> Get(Expression<Func<T, bool>> predicate, params string[] includes)
        {
            IQueryable<T> query = Context.Set<T>();
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
            query = query.Where(predicate);
            var enabledQuery = query as IQueryable<IEnabledEntity>;
            if (enabledQuery != null)
                query = enabledQuery.Where(e => e.IsEnabled).Cast<T>();
            return query;
        }
