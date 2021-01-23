public IQueryable<T> GetAllbySearch(
            int pageNumber = 1, int pageSize = 10,
            Dictionary<string, dynamic> filterParams = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
            bool allIncluded = false
            , Func<IQueryable<T>, IOrderedQueryable<T>> order = null)
        {
            var query = _entity.AsQueryable();
            if (include != null && !allIncluded)
            {
                query = include(query);
            }
            if (allIncluded && include == null)
            {
                foreach (var property in _context.Model.FindEntityType(typeof(T)).GetNavigations()
                    .Where(r => !r.IsCollection()))
                    query = query.Include(property.Name);
            }
            if (filterParams != null && filterParams.Any())
            {
                if (filterParams.Any(r => r.Value != null))
                {
                    var expression = GetSearchFilter(filterParams);
                    if (order != null)
                    {
                        return order(query.Where(expression));
                    }
                    else
                    {
                        return query.Where(expression));
                    }
                }
            }
            if (order != null)
            {
                return order(query);
            }
            else
            {
                return query;
            }
        }
