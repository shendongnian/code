    public virtual IQueryable<UserRole> GetAsQueryable(Expression<Func<UserRole, bool>> where, string includeProperties = null)
    {
        IQueryable<UserRole> query = _dataContext.UserRoles.Where(where);
        if (includeProperties != null)
        {
            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }
        }
        return query.AsQueryable();
    }
