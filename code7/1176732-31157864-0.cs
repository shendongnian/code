	using System;
	using System.Collections.Generic;
	using MongoDB.Bson.Serialization;
	using MongoDB.Driver;
	namespace ConsoleApplication2
	{
		class Program
		{
			private static IMongoDatabase _database;
			static void Main(string[] args)
			{
				var dbClient = new MongoClient("mongodb://localhost");
				_database = dbClient.GetDatabase("Test");
				BsonClassMap.RegisterClassMap<DemoClass>(); //This class can be used
				MongoInsert();
				MongoGet();
			}
			static private void MongoInsert()
			{
				//Create an entity
				var person = new DemoClass
				{
					FirstName = "Jane",
					Age = 12,
					PetNames = new List<dynamic> { "Sherlock", "Watson" }
				};
				//Insert into db, and wait for it (wanted for this example)
				_database.GetCollection<dynamic>("people").InsertOneAsync(person).Wait();
			}
			static private void MongoGet()
			{
				var names = _database.GetCollection<DemoClass>("people")
					.Find(x => x.FirstName == "Jane")
					.SortBy(x => x.Age)
					.Project(x => x.FirstName + " " + x.LastName) //This is important for the foreach-loop
					.ToListAsync();
				//Write all found entities
				foreach (var name in names.Result)
				{
					Console.WriteLine(name);
				}
			}
		}
		public class DemoClass
		{
			public string FirstName { get; set; }
			public string LastName { get; set; }
			public int Age { get; set; }
			public List<dynamic> PetNames { get; set; }
		}
	}
