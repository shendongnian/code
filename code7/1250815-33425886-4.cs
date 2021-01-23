	var vl = new WhereConstraint<MyObject>(o => o.Value > 5);
    // Linq to Objects
	List<MyObjects> list = GetObjectsList();
	var filteredList = list.Where(vl).ToList(); // no special handling
    // Linq to Entities
    IQueryable<MyObjects> myObjects = new MyObjectsContext().MyObjects;
    var filteredList2 = myObjects.Where(vl).ToList(); // no special handling
