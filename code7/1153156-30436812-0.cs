    var searchRequest = new SearchRequest
    {
    	Query = new QueryContainer(new MatchQuery{Field = new PropertyPathMarker{Name = "name"}, Query = "test"}),
        Highlight = new HighlightRequest
        {
            Fields = new FluentDictionary<PropertyPathMarker, IHighlightField>
            {
    	        {
    		        new PropertyPathMarker {Name = "name"},
    		        new HighlightField {PreTags = new List<string> {"<tag>"}, PostTags = new List<string> {"</tag>"}}
    	        }
            }
        }
    };
    
    var searchResponse = client.Search<Document>(searchRequest);
