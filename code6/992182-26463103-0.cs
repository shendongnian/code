    void Main()
    {
    	var example = new BsonDocument{
    		{ "customer", new BsonDocument { { "email" , "homerjay@simpsons.com" } }}
    	};
    	
    	var email = example.GetPath("customer.email").AsString;
    	
    	Console.WriteLine(email);
    }
    
    public static class MongoDbHelper
    {
    	public static BsonValue GetPath(this BsonValue bson, string path)
    	{
    		if (bson.BsonType != BsonType.Document)
    		{
    			throw new Exception("Not a doc");
    		}
    		
    		var doc = bson.AsBsonDocument;
    		
    		var tokens = path.Split(".".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
    		
    		if (tokens.Length == 0 )
    		{
    			return doc;
    		}
    		
    		if (!doc.Contains(tokens[0]))
    		{
    			return BsonNull.Value;
    		}
    		
    		if (tokens.Length > 1)
    		{
    			return GetPath(doc[tokens[0]], tokens[1]);
    		} 
    		
    		return doc[tokens[0]];
    	}
    }
