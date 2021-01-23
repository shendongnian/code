    var sd = new SearchDescriptor<MyData>();
    
    sd = sd.QueryRaw(<raw query string>);
    
    if (<should sort>)
    {
        string fieldToBeSortedOn; // input from user
        bool sortInAscendingOrder; // input from user
        if (sortInAscendingOrder)
        {
            sd = sd.Sort(f => f
                .Ascending()
                .OnField(fieldToBeSortedOn));
        }
        else
        {
            sd = sd.Sort(f => f
                .Descending()
                .OnField(fieldToBeSortedOn));
        }
    }
    
    if (<should compute aggregations>)
    {
        sd = sd.Aggregations(a => a
            .Terms(
                "term_aggs", 
                t => t
                    .Field(<name of field to compute terms aggregation on>)));
    }
    var search = esClient.Search<MyData>(s => sd);
