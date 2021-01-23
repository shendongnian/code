        public T GetSingle<T>(Expression<Func<T, bool>> predicate,
                   params Expression<Func<T, object>>[] navigationProperties)
        {            
            IQueryable<T> query = _entities.Set<T>();
            foreach (var navigationProperty in navigationProperties)
            {
                query = query.Include(navigationProperty);
            }
            return query.FirstOrDefault(predicate);
        }
