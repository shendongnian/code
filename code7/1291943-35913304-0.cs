    if (typeof(IActivable).IsAssignableFrom(typeof(TEntity)))
    {
        return ((IQueryable<IActivable>)(this.repository.Get()))
            .Where(q => q.Active)
            .Cast<TEntity>();
    }
