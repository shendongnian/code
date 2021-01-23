    var make = new Make {Id = "1", Models = new List<Cars>
    {
        new Cars{Name = "test"},
        new Cars{Name = "test2"}
    }};
    
    make.Models.RemoveAt(1);
    
    var updateResponse = client.Update<Make>(descriptor => descriptor
    	.Id("1")
    	.Doc(make));
