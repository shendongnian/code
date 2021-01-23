    public override IQueryable<T> GetEverything(Expression<Func<T, bool>> predicate)
    {
        return Get()
            .Where(i => i.Active == true)
            .Where(predicate)
            .Select(i => new T(i));
    }
