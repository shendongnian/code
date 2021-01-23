	using System.Collections.Generic;
	using System.Threading.Tasks;
	using MongoDB.Bson;
	using MongoDB.Driver;
	... Your class and method declaration ...
	IMongoClient client = new MongoClient ("mongodb://localhost:27017/test");
	IMongoDatabase database = client.GetDatabase("test");
	IMongoCollection<BsonDocument> collection = database.GetCollection<BsonDocument> ("collection");
	var filter = Builders<BsonDocument>.Filter.AnyIn ("Source", new[]{"VG", "IGN"});
	var cursor = await collection.FindAsync (filter);
	var docs = cursor.ToList();
