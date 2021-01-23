	class MyClass
	{
		public IBulkResponse IndexDocuments<T>(IEnumerable<Topic> documents)
			where T : Topic
		{
			var derived = documents.OfType<T>();
			return ElasticConnector.Client.Bulk(b => b.CreateMany(derived));
		}
		public IEnumerable<IBulkResponse> IndexDocumentsByType(IEnumerable<Topic> documents)
		{
			var groups = documents.GroupBy(x => x.GetType());
			var method = typeof(MyClass).GetMethod(nameof(IndexDocuments)); //prior to c#6, typeof(MyClass).GetMethod("IndexDocuments")
			foreach (var group in groups)
			{
				var generic = method.MakeGenericMethod(group.Key);
				var result = generic.Invoke(this, new object[] { group });
				yield return result as IBulkResponse;
			}
		}
	}
	class Program
	{
		static void Main(string[] args)
		{
			var documents = new Topic[] { new TopicA(), new TopicA(), new TopicB(), new Topic() };
			var result = new MyClass().IndexDocumentsByType(documents);
			Console.WriteLine(result.Count()); //writes 3
		}
	}
