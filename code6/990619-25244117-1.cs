	static void Main(string[] args)
	{
		//using the object initializer syntax
		client.Search<Product>(new SearchRequest()
		{
			Query = query
		});
		//using fluent syntax
		client.Search<Product>(s => s.Query(query));
	}
