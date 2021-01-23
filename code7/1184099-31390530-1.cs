    public static Task<IBulkResponse> IndexManyAsync<T>(this IElasticClient client, 
                                                        IEnumerable<T> objects, 
                                                        string index = null, 
                                                        string type = null) where T : class
	{
		// <snip>
	}
