    public static bool IdenticalValues<TEntity, TProperty>(this IEnumerable<TEntity> matchedEntities, Func<TEntity, TProperty> matchExpression)
    {
        var itemToMatch = matchedEntities.First();
        if (matchedEntities.All(p => matchExpression(p) == matchExpression(itemToMatch)))
            return true;
        else
            return false;
    }
