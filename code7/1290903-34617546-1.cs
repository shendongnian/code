    var parent = db.Tests.FirstOrDefault(x => x.ID.Equals(hardcodedBusinessUnitID)).ID;
    // a list of the type of your object, to store all the items
    var items = new List<Test>();
    items.Add(parent)
    // make a new list that will be used to search the table
    searchItems = new List<Test>(items);
    while (searchItems.Any())
    {
        var ids = searchItems.Select(i => i.ID).ToList();
        searchItems = db.Tests.Where(t => 
            t.Parent_ID.HasValue && ids.Contains(t.Parent_ID.Value)).ToList();
        items.AddRange(searchItems);
    }
    List<int> list = items.Select(i => i.ID).ToList();
