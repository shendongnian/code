    public async Task Add(string productId, string categoryId, SubCategory newSubCategory)
    {
        var filter = Builders<Product>.Filter.And(
             Builders<Product>.Filter.Where(x => x.Id == productId), 
             Builders<Product>.Filter.Eq("Categories.Id", categoryId));
        var update = Builders<Product>.Update.Push("Categories.$.SubCategories", newSubCategory);
        await collection.FindOneAndUpdateAsync(filter, update);
    }
