    context.Projects.AddOrUpdate(x => x.Name,
    new Project()
    {
       ID = 1,
       Name = "Project 1",
       CompanyID = 3,
       Resources = new List<Resource>
       {
           new Resource { FirstName = "Linda", LastName = "West" },
           new Resource { FirstName = "Joe", LastName = "East" }
       }
    );
