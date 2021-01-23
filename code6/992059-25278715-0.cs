    //Assumes you have a Entity() object of the parent entity
    //somehow you have to know the parent entity record's Id
    
    Guid parentId = parentEntity.Id;
    var query = new QueryExpression("new_childentity");
    query.Criteria.AddCondition(new ConditionExpression("new_lookupfield", ConditionOperator.Equal, parentId));
    query.ColumnSet = new ColumnSet(true);
    var results = service.RetrieveMultiple(query);
    if (results.Entities.Any())
    {
         //Do your processing here
    }
    else
    {
         //Do whatever when there are no child entities
    }
