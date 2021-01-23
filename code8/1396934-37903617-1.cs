    public T GetEntry(ObjectId id)
    {
        IMongoCollection<T> collections = db.GetCollection<T>(database);
        var parameterExpression = Expression.Parameter(typeof(T), "object");
        var propertyOrFieldExpression = Expression.PropertyOrField(parameterExpression, "Id");
        var equalityExpression = Expression.Equal(propertyOrFieldExpression, Expression.Constant(id, typeof(int)));
        var lambdaExpression = Expression.Lambda<Func<T, bool>>(equalityExpression, parameterExpression);
        var getObj = collections.Find(lambdaExpression).FirstOrDefault();
        return getObj;
    }
