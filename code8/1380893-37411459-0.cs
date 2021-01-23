	public void CopyEntitiesToMongo<TEntity>(DbContext entityFrameworkContext,
                                             MongoDatabase mongoDatabase, 
                                             string collectionName)
	{
		var entityTypeResults = context.DbSet<TEntity>().ToList();
		var entityTypeMongoCollection = mongoDatabase.GetCollection<TEntity>(collectionName);
		entityTypeMongoCollection.InsertMany(entityTypeResults);
	}
	
