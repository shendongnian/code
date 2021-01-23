    public class NeolineReorganizedMongoResult
    {
        public ObjectId _id { get; set; }
	    public List<string> DealerListAbout { get; set; }
    }
    public async Task<UpdateResult> Update(Expression<Func<T, bool>> filter,
    T  entity)
    {
                
                if (entity._id == null)
                    await Insert(entity);
                
                var result = await collection.UpdateOneAsync(
                                        Builders<T>.Filter.Where(filter),
                                        Builders<T>.Update.Set(x => x.dealer_code, entity.dealer_code));
    
    
                if (result.IsAcknowledged)
                {
                    Console.WriteLine("Success");
                }
                return result;
    }
    var element = result.Result.Where(x => x.dealer_code.Trim() == "8888").FirstOrDefault();
            if (element == null) return;
            element.DealerListAbout = new List<string>
            {
                "Name1", "Name2", "Name3", "Name4" 
            };
            foreach (var item in element.DealerListAbout)
            {
                using (Task updated = list.UpdateSetProperty(x => x.dealer_code.Equals("8888"), element.DealerListAbout, item))
                {
                    updated.Wait();
                    if (!updated.IsFaulted)
                    {
                        Console.Write("Success");
                        var value = list.SearchFor(x => x.dealer_code.Equals("5430")).Result;
                    }
                    else
                    {
                        Console.Write("Failed");
                    }
                }
            }
