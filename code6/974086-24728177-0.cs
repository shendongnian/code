	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	
	using MongoDB.Bson;
	using MongoDB.Driver;
	using MongoDB.Bson.Serialization.Attributes;
	
	public class MyDoc {
		[BsonIgnoreIfDefault]
		public ObjectId? Id;
		public int X;
	}
	
	public static class Program {
		public static void Main(string[] args) {
			MongoClient client = new MongoClient(); // connect to localhost
			var server = client.GetServer ();
			var database = server.GetDatabase("test");
			var collectionSettings = new MongoCollectionSettings { AssignIdOnInsert = false };
			var collection = database.GetCollection<MyDoc>("nullid", collectionSettings);
	
			// Insert document without _id
			collection.Insert(new MyDoc { X = 1});
		}
	}
