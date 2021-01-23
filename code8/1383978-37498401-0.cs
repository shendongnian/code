    public async Task<IEnumerable<T>> GetPagedAsync(
           Func<IQueryable<T>,
           IOrderedQueryable<T>> orderBy,
           Expression<Func<T, bool>> filter = null,
           int? page = 0,
           int? pageSize = null, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = dbSet;
            
            if (filter != null)
            {
                query = query.Where(filter);
            }
            //Includes
            if (includes != null && includes.Any())
            {
                query = includes.Aggregate(query,
                          (current, include) => current.Include(include));
            }
            if (orderBy != null)
                query = orderBy(query);
            else
                throw new ArgumentNullException("The order by is necessary in Pagining");
           
            if (page != null && page > 0)
            {
                //(0-1)
                if (pageSize == null) throw new ArgumentException("The take paremeter supplied is null, It should be included when skip is used");
                query = query.Skip(((int)page - 1) * (int)pageSize);
            }
            if (pageSize != null)
            {
                query = query.Take((int)pageSize);
            }
            return await query.ToListAsync();
        }
