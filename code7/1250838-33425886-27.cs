	var greaterThan5 = new WhereConstraint<MyObject>(o => o.Value > 5);
    // Linq to Objects
	List<MyObject> list = GetObjectsList();
	var filteredList = list.Where(greaterThan5).ToList(); // no special handling
    // Linq to Entities
    IQueryable<MyObject> myObjects = new MyObjectsContext().MyObjects;
    var filteredList2 = myObjects.Where(greaterThan5).ToList(); // no special handling
