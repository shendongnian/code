    // Create the list.
    var list = new List<IOrderDate>();
    list.Add(new ObjA() { DateOfCreation = DateTime.Now.AddDays(100)});
    list.Add(new ObjB() { CreationDate = DateTime.Now.AddDays(-250) });
    // Ascending.
    list.Sort(new OrderDateComparer());
    // Decending
    list.Sort(new OrderDateComparer()); // Redundant here.
    list.Reverse();
