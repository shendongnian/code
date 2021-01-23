    using System.Reflection;
    using MongoDB.Bson;
    using MongoDB.Bson.IO;
    using MongoDB.Bson.Serialization;
    
    // Custom Serializer
    public static class MyBsonSerializer
    {
    	public static Quest DeserializeQuest(BsonDocument bson)
    	{
    		Quest quest = new Quest();
    		var properties = typeof(Quest).GetProperties(BindingFlags.Public | BindingFlags.Instance).ToList();
    
    		foreach (var element in bson.Elements)
    		{
    			switch (element.Name)
    			{
    				case "GalleryImagePaths":
    					List<HttpFile> paths = new List<HttpFile>();
    					foreach (var path in element.Value.AsBsonArray)
    					{
                            var httpFile = new HttpFile();
                            // Set FilePath and UriPath
    						paths.Add(httpFile);
    					}
    					quest.GalleryImagePaths = paths;
    					break;
    				case "_id":
    					properties.First(p => p.Name == element.Name).SetValue(quest, new ObjectId(element.Value.ToString()));
    					break;
    				case "Name":
    					properties.First(p => p.Name == element.Name).SetValue(quest, element.Value.ToString());
    					break;
    			}
    		}
    		return quest;
    	}
    	
    	public static BsonDocument SerializeQuest(Quest quest)
    	{
    		BsonDocument bson = new BsonDocument();
    		bson.Add(new BsonElement("Name", quest.Name));
    		var paths = quest.GalleryImagePaths.Select(h => h.UriPath); 
    		// OR quest.GalleryImagePaths.Select(h => h.FilePath)
    		bson.Add(new BsonElement("GalleryImagePaths", new BsonArray(paths)));
    		
    		return bson;
    	}
    }
