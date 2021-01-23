    public UpdateDefinition<TDocument> BuildUpdate<TDocument>(TDocument doc) {
        var builder = Builders<TDocument>.Update;
        var updates = new List<UpdateDefinition<TDocument>>();
        foreach (PropertyInfo prop in typeof(TDocument).GetProperties())
        {
            if (prop.PropertyType == typeof(MongoDB.Bson.ObjectId))
                continue; // Mongo doesn't allow changing Mongo IDs
            if (prop.GetValue(doc) == null)
                continue; // If we didn't set a value, don't change existing one
            updates.add(builder.Set(prop.Name, BsonDocumentWrapper.Create(prop.PropertyType, prop.GetValue(doc))));
        }
        return builder.Combine(updates);
    }
