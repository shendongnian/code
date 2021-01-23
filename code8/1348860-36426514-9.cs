    var lindaResource = new Resource { FirstName = "Linda", LastName = "West" };
    var joeResource = new Resource { FirstName = "Joe", LastName = "East" };	
	context.resource.AddOrUpdate(x => x.FirstName, 
        lindaResource, 
        joeResource);
    context.Projects.AddOrUpdate(x => x.ID,
		new Project()
		{
		   ID = 1,
		   Name = "Project 1",
		   CompanyID = 3,
		   Resources = new List<Resource> { lindaResource }
		},
		new Project()
		{
		   ID = 2,
		   Name = "Project 2",
		   CompanyID = 3,
		   Resources = new List<Resource> { lindaResource, joeResource }
		});
