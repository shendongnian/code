    // Create the list.
    var list = new List<IOrderDate>();
    list.Add(new ObjA() { DateOfCreation = DateTime.Now.AddDays(100)});
    list.Add(new ObjB() { CreationDate = DateTime.Now.AddDays(-250) });
    // Ascending.
    list = list.OrderBy(o => o.CreateDate).ToList();
    // Decending
    list = list.OrderByDescending(o => o.CreateDate).ToList();
