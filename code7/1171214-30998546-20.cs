    client.Index(new Person
    {
        Id = 1, 
    	Car = new List<NestedType> {new NestedType {Carname = "car1"}}
    });
    client.Index(new Person
    {
        Id = 2,
        Car = new List<NestedType> {new NestedType {Carname = "car1"}, new NestedType {Carname = "car2"}}
    });
    client.Index(new Person
    {
        Id = 3,
        Car = new List<NestedType> { new NestedType {Carname = "car2"}}
    });
    
    client.Refresh();
