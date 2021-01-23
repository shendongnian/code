     protected virtual void AttachIfNot(TEntity entity)
        {
            if (!_dbSet.Local.Contains(entity))
            {
                _dbSet.Attach(entity);
            }
        }
