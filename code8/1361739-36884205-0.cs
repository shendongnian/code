        filter =  builder.ElemMatch("Days", Builders<DbDayRecord>.Filter.Eq("DateOfDay", dayRecord.DateOfDay));
        result = await stores.FindAsync(filter);
        if (await result.AnyAsync())  // Record already exists, update it
        {
            var update = Builders<UserDayStore>.Update.Set("Days.$", dayRecord).CurrentDate("LastModified");
             
            var updateResult = await stores.UpdateOneAsync(filter, update);
            return (updateResult.ModifiedCount == 1);
        }
        else // Add new Record to array
        {
            filter = Builders<UserDayStore>.Filter.Eq("Id", storeID);
            var update = Builders<UserDayStore>.Update.AddToSet("Days", dayRecord).CurrentDate("LastModified");
            var updateResult = await stores.UpdateOneAsync(filter, update);
            return (updateResult.ModifiedCount == 1);
        }
