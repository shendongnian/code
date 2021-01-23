     public IList<T> GetList<T>(Func<T, bool> predicate, params Expression<Func<T, object>>[] include) where T : class, IEntity
        {
            // where Context is my DbContext
            IQueryable<T> query = this.Context.Set<T>();
            foreach (var navigationProperty in include)
            {
                query = query.Include(navigationProperty);
            }
            return query?.Where(predicate).ToList();
        }
