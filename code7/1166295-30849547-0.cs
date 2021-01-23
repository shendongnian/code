    public void ProcessQuery(QueryContainer query = null)
    {
    
       var searchResult = this._client.Search<T>(
                    s => s
                        .Index(MyIndex)
                        .AllTypes()
                        .From(0)
                        .Take(10)
                        .Query(query ?? new MatchAllQuery()) // Now works
                        .SearchType(SearchType.Scan)
                        .Scroll("2m")
                    );
    }
