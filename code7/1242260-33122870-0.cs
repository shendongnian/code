    public IGenericRepository<TEntity> Repository<TEntity>() where TEntity : class
    {
            if (repositories.Keys.Contains(typeof(TEntity)) == true)
            {
                return repositories[typeof(TEntity)] as IGenericRepository<TEntity>;
            }
            GenericRepository<TEntity> repo = new GenericRepository<TEntity>(_context);
            repositories.Add(typeof(TEntity), repo);
            return repo;
    }
