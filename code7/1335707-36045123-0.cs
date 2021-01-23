    var settings = new ConnectionSettings()
    	.DefaultIndex(indexName)
    	.MapDefaultTypeNames(dictionary => dictionary.Add(typeof(Dictionary<string,object>), "yourTypeName"))
    	.DisableDirectStreaming()
    	.PrettyJson();
    
    var client = new ElasticClient(settings);
