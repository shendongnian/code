        public IQueryable<TEntity> FindNear<TEntity>(string collectionName, Expression<Func<TEntity, object>> field, double longitude, double latitude, double maxDistanceInKm) where TEntity : IEntity
        {
            var collection = database.GetCollection<TEntity>(collectionName);
            var point = GeoJson.Point(GeoJson.Geographic(longitude, latitude));
            var filter = Builders<TEntity>.Filter.Near(field, point, maxDistanceInKm * 1000);
            return collection.Find(filter).ToList().AsQueryable();
        }
