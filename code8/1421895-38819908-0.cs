    void Main()
    {
    	var connectionPool = new SingleNodeConnectionPool(new Uri("http://localhost:9200"));
        var settings = new ConnectionSettings(connectionPool);
    
        var client = new ElasticClient(settings);
    
        var itemsPerPage = 20;
        var pattern = "match query";
    
        client.Search<SearchItem>(x => x
            .Sort(so => so
                .Descending("_score")
            )
            .Size(itemsPerPage)
            .Query(q => q
                .MultiMatch(m => m
                    .Fields(fs => fs
                        .Field(p => p.Field1)
                        .Field(p => p.Field2)
                        .Field(p => p.Field3)
                        .Field(p => p.Field4)
                        .Field(p => p.Field5)
                        .Field(p => p.Field6)
                    )
                    .Operator(Operator.And)
                    .Query(pattern)
                ) && q
                .Range(ra => ra
                    .Field(ff=>ff.SalePrice)
                    .GreaterThan(1000)
                )
            )
        );
    }
    
    public class SearchItem
    {
        public int SalePrice { get; set; }
    
        public string Field1 { get; set; }
        
        public string Field2 { get; set; }
        
        public string Field3 { get; set; }
        
        public string Field4 { get; set; }
        
        public string Field5 { get; set; }
        
        public string Field6 { get; set; }
    }
