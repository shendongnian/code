    private IList CollectionToList(object value)
    {
        var collectionType = value.GetType().GenericTypeArguments.First();
        var method = typeof(Enumerable).GetMethod("ToList");
        var genericMethod = method.MakeGenericMethod(collectionType);
        return (IList)genericMethod.Invoke(null, new[] { value });
    }
