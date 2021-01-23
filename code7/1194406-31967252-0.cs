          public virtual IEnumerable<T> Get(
          Expression<Func<T, bool>> filter = null,
          Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
          string includeProperties = "")
        {
           
                IQueryable<T> query = _context.Set<T>();
                if (filter != null)
                {
                    query = query.Where(filter);
                }
                if (includeProperties != null)
                    foreach (var includeProperty in includeProperties.Split
                        (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                    {
                        query = query.Include(includeProperty);
                    }
                return query.ToList();
            }
            
        }
