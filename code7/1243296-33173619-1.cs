    private EntityCollection GetAssociatedEntityItems(string relationshipName, string relatedEntityName, string entityName, Guid entityId)
        {
        	EntityCollection result = null;
        		QueryExpression query = new QueryExpression();
        		query.EntityName = relatedEntityName;
        		query.ColumnSet = new ColumnSet(false);
        		Relationship relationship = new Relationship();
        		relationship.SchemaName = relationshipName;
        		relationship.PrimaryEntityRole = EntityRole.Referencing;
        		RelationshipQueryCollection relatedEntity = new RelationshipQueryCollection();
        		relatedEntity.Add(relationship, query);
        		RetrieveRequest request = new RetrieveRequest();
        		request.RelatedEntitiesQuery = relatedEntity;
        		request.ColumnSet = new ColumnSet(true);
        
        		request.Target = new EntityReference
        		{
        			Id = entityId,
        			LogicalName = entityName
        		};
        		RetrieveResponse response = (RetrieveResponse)serviceProxy.Execute(request);
        		RelatedEntityCollection relatedEntityCollection = response.Entity.RelatedEntities;
        		if (relatedEntityCollection.Count > 0)
        		{
        			if (relatedEntityCollection.Values.Count > 0)
        			{
        				result = (EntityCollection)relatedEntityCollection.Values.ElementAt(0);
        			}
        		}
        	return result;
        }
