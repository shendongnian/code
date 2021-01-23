	public static void Main()
	{
		var client = new MongoClient("mongodb://localhost:27017");
		var database = client.GetDatabase("test");
		var collection = database.GetCollection<InnerDocument>("irpunch");
		
		var aggregationDocument = collection.Aggregate()
			.Match(x=>x.LastUpdate> DateTime.Now.AddDays(-40))
			.SortByDescending(x => x.LastUpdate)
			.Group(BsonDocument.Parse("{ _id:'$Emp_ID', documents:{ '$push':'$$ROOT'}}"))
			.Project<AggregationResult>(BsonDocument.Parse("{ _id:1, documents:{ $slice:['$documents', 3]}}")).ToList()
			;
		foreach (var aggregationResult in aggregationDocument)
		{
			foreach (var innerDocument in aggregationResult.documents)
			{
				Console.WriteLine($"empID: {aggregationResult._id}, doc date: {innerDocument.LastUpdate}");
			}
			Console.WriteLine();
		}
		Console.ReadLine();
	}
	public class AggregationResult
	{
		public int _id { get; set; }
		public InnerDocument[] documents { get; set; }
	}
	public class InnerDocument
	{
		public ObjectId Id { get; set; }
		public string Emp_ID { get; set; }
		public DateTime LastUpdate { get; set; }
	}
