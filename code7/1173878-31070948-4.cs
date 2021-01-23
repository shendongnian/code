    var indicesOperationResponse = client.CreateIndex(indexName, c => c
        .AddMapping<MyDocument>(m => m.MapFromAttributes()));
    
    var myDocument = new MyDocument {Id = 1, Description = "test cat test"};
    client.Index(myDocument);
    client.Index(new MyDocument {Id = 2, Description = "river"});
    client.Index(new MyDocument {Id = 3, Description = "test"});
    client.Index(new MyDocument {Id = 4, Description = "river"});
    
    client.Refresh();
