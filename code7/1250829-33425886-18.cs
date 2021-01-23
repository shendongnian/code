	var greateThan5 = new WhereConstraint<MyObject>(o => o.Value > 5);
    // Linq to Objects
	List<MyObjects> list = GetObjectsList();
	var filteredList = list.Where(greateThan5).ToList(); // no special handling
    // Linq to Entities
    IQueryable<MyObjects> myObjects = new MyObjectsContext().MyObjects;
    var filteredList2 = myObjects.Where(greateThan5).ToList(); // no special handling
