    public static ObjectContext GetContext(this IEntityWithRelationships entity)
    {
      if (entity == null)
        throw new ArgumentNullException("entity");
    
      var relationshipManager = entity.RelationshipManager;
      var relatedEnd = relationshipManager.GetAllRelatedEnds().FirstOrDefault();
    
      if (relatedEnd == null)
        throw new Exception("No relationships found");
    
      var query = relatedEnd.CreateSourceQuery() as ObjectQuery;
      if (query == null)
        throw new Exception("The Entity is Detached");
    
      return query.Context;
    }
