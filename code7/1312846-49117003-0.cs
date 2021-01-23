    // Example lists, a solution for populating will follow
    var Names = new List<string> { "Adam", "Joe", "Bob" };
    // These two deliberately left blank for demonstration purposes
    var specialties = new List<string>();
    var ranks = new List<string>();
    using(var dbContext = new MyDbContext())
    {
        var list = dbContext.MyTable
           .FilterByNames(names)
           .FilterBySpecialties(specialties)
           .FilterByRanks(ranks)
           .Select(...)
           .ToList();
    }
