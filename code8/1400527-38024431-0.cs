        private void applySorts(ref IQueryable<TEntity> query, Dictionary<Expression<Func<TEntity, dynamic>>, string> sorts)
    {
        if (sorts != null)
        {
            IOrderedQueryable<TEntity> tempQuery = null;
            bool isFirst = true;
            foreach (var s in sorts.Reverse())
            {
                Expression<Func<TEntity, dynamic>> expr = s.Key;
                string dir = s.Value;
                if (first) 
                {
                    first = false;
                    if (dir == "d")
                    {
                        tempQuery = query.OrderByDescending(expr);
                    }
                    else
                    {
                        tempQuery = query.OrderBy(expr);
                    }
                }
                else 
                {   
                    if (dir == "d")
                    {
                        tempQuery = tempQuery.ThenByDescending(expr);
                    }
                    else
                    {
                        tempQuery = tempQuery.ThenBy(expr);
                    }
                }
            }
            query = tempQuery;
        }
    }
