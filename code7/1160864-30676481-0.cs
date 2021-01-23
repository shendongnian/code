    public async Task<IQueryable<T>> WhereAsync(Expression<Func<T, bool>> predicate) {
        // remembering that dataSource is talking to a backing store of TypedEntity<T>
        var typeName = typeof(T).FullName;
        var queryable = dataSource.Where(x => x.Type == typeName)
            .Select(x => x.Item)
            .Where(predicate);
       // ... other business logic stuff
    }
