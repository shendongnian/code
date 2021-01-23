    var searchRequest = new SearchRequest
    {
    	Query = new QueryContainer(new MatchQuery{Field = Property.Path<Document>(p => p.Name), Query = "test"}),
        Highlight = new HighlightRequest
        {
            Fields = new FluentDictionary<PropertyPathMarker, IHighlightField>
            {
    	        {
    		        Property.Path<Document>(p => p.Name),
    		        new HighlightField {PreTags = new List<string> {"<tag>"}, PostTags = new List<string> {"</tag>"}}
    	        }
            }
        }
    };
    
    var searchResponse = client.Search<Document>(searchRequest);
