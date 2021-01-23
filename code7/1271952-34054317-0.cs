    var providers = Repository.Query<Company>()
        .Where(c => !c.IsDeleted)
        .Select(c => new { c.Description, c.Id }) // <<== Prepare raw data
        .AsEnumerable() // <<== From this point it's LINQ to Object
        .Select(c => new { c.Description, Id = "C"+c.Id }); // <<== Construct end result
