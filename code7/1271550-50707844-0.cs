    public IMongoQueryable<MyType> GetFiltered(Expression<Func<MyType, bool>> predicate)
    {
        return Database.GetCollection<MyType>(typeof(MyType).Name).AsQueryable()
            .Where(predicate);
    }
