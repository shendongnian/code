    public async Task<List<T>> QueryDB(this IMongoCollection<T> collection, T entity) where T : Idable
        {
            var filter = Builders<T>.Filter.Eq(ts => ts.id, entity.id);
            List<T> fetchedData = new List<T>()
            using (var cursor = await collection.FindAsync(filter))
            {
                  while (await cursor.MoveNextAsync())
                  {
                         var batch = cursor.Current;
                          foreach (T res in batch)
                                fetchedData.Add(res);
                  }
            }
            return fetchedData;
            
          }
    
    interface Idable
    {
    string id {get;};
    }
    public class User : Idable
    {
    ...
    }
