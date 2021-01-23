        var filter = Builders<Contact>.Filter.And(
                Builders<Contact>.Filter.Eq("Name", "Ken"),
                Builders<Contact>.Filter.Eq("ContactNo.Number", "123"));
        var update = Builders<Contact>.Update.Set("ContactNo.$.Type", "Fiber");
        collection.UpdateOneAsync(filter, update).Wait();
