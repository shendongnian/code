    public UpdateDefinition<TDocument> BuildUpdate<TDocument>(TDocument doc) {
        var builder = Builders<TDocument>.Update;
        var updates = new List<UpdateDefinition<TDocument>>();
        foreach (PropertyInfo prop in typeof(TDocument).GetProperties())
        {
            if (prop.PropertyType == typeof(MongoDB.Bson.ObjectId))
                continue; // Mongo doesn't allow changing Mongo IDs
            if (prop.GetValue(doc) == null)
                continue; // If we didn't set a value, don't change existing one
            switch (prop.PropertyType.Name) {
            case "AddressData":
                updates.add(builder.Set(prop.Name, (AddressData)prop.GetValue(doc)));
                break;
            // Etc., etc. Many other type names here
            default:
                updates.add(builder.Set(prop.Name, prop.GetValue(doc)));
                break;
            }
        }
        return builder.Combine(updates);
    }
