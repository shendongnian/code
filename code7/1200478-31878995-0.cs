        var numberOfElementsInArray = 3;
        var filter = Builders<Contact>.Filter.Eq("Name", "Ken");
        var update = Builders<Contact>.Update.Combine(Enumerable.Range(0, numberOfElementsInArray)
                .Select(i => Builders<Contact>.Update.Set("ContactNo." + i + ".Type", "PABX")));
        collection.UpdateOneAsync(filter, update).Wait();
