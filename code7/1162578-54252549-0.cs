cs
public async Task Add(string productId, string categoryId, SubCategory newSubCategory)
{
    var filter = Builders<Product>.Filter.And(
         Builders<Product>.Filter.Where(x => x.Id == productId), 
         Builders<Product>.Filter.ElemMatch(x => x.Categories, c => c.Id == categoryId));
    var update = Builders<Product>.Update.Push(x => x.Categories[-1].SubCategories, newSubCategory);
    await collection.FindOneAndUpdateAsync(filter, update);
}
And get yourself free of using hard-coded property names inside strings.
