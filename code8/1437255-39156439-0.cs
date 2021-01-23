    void Main()
    {
    	var pool = new SingleNodeConnectionPool(new Uri("http://localhost:9200"));
    	var defaultIndex = "searchable-items";
    	var connectionSettings = new ConnectionSettings(pool)
    			// specify the default index to use if
                // 1. no index is specified on the request
                // 2. no index can be inferred from the C# POCO type 
                .DefaultIndex(defaultIndex);;
    				
    	var client = new ElasticClient(connectionSettings);
    	
        client.CreateIndex(defaultIndex, c => c
            .Mappings(m => m
                .Map<MyDocument>(mm => mm
                    // map MyDocument, letting
                    // NEST infer the mapping from the property types
                    // and attributes applied to them
                    .AutoMap()
                )
            )
        );
    
        var docs = new[] {
            new MyDocument
            {
                Id = 1,
                Name = "name 1",
                Date = new DateTime(2016,08,26),
                Slug = "/slug1"
            },
            new MyDocument
            {
                Id = 2,
                Name = "name 2",
                Date = new DateTime(2016,08,27),
                Slug = "/slug2"
            }
        };
    
        client.IndexMany(docs);
    }
    
    public class MyDocument
    {
        [Number(Index = NonStringIndexOption.No)]
        public long Id { get; set; }
        [String(Name = "name")]
        public string Name { get; set; }
        [String(Name = "slug", Index = FieldIndexOption.No)]
        public string Slug { get; set; }
        [Date(Format = "dd-MM-yyyy", Index = NonStringIndexOption.No)]
        public DateTime Date { get; set; }
    }
