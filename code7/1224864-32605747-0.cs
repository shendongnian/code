        public T GetSingle(Expression<Func<T, bool>> predicate, 
                       Expression<Func<T, object>>[] navigationProperty)
        {
             var query = _entities.Set<T>().Include(navigationProperty)
                                  .FirstOrDefault(predicate);
             return query;        
        }
