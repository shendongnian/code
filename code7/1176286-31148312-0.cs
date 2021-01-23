    public async Task<TValue> GetFieldValue<TEntity, TValue>(string id, Expression<Func<TEntity, TValue>> fieldExpression) where TEntity : IEntity
    {
        var propertyValue = await collection
            .Find(d => d.Id == id)
            .Project(new ProjectionDefinitionBuilder<TEntity>().Expression(fieldExpression))
            .FirstOrDefaultAsync();
        return propertyValue;
    }
