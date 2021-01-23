    // Get all ObjectDependencies containing ov2
    // Output:
    // d1
    // d2
    // d3
    Console.WriteLine("Get all ObjectDependencies containing ov2");
    IEnumerable<ObjectDependency> ov2Dependencies =
    	dependencies
    	//.Where(d => d.ObjectVersion1.Id == ov2.Id || d.ObjectVersion2.Id == ov2.Id)
    	.WhereContainsObjectVersion(ov2.Id)
    	.OrderBy(d => d.Name);
    foreach (ObjectDependency dependency in ov2Dependencies)
    {
    	Console.WriteLine(dependency.Name);
    }
    
    // Get all ObjectVersions dependent on ov2
    // Output:
    // 1
    // 3
    // 4
    Console.WriteLine("Get all ObjectVersions dependent on ov2");
    IEnumerable<ObjectVersion> ov2AllDependentObjectVersions =
    	dependencies
    	//.Where(d => d.ObjectVersion1.Id == ov2.Id || d.ObjectVersion2.Id == ov2.Id)
    	//.Select(d => d.ObjectVersion1)
    	//.Union(dependencies.Where(d => d.ObjectVersion1.Id == ov2.Id || d.ObjectVersion2.Id == ov2.Id)
    	//.Select(d => d.ObjectVersion2))
    	//.Where(o => o.Id != ov2.Id)
    	.SelectDependentObjectVersions(ov2.Id)
    	.OrderBy(o => o.Id);
    foreach (ObjectVersion ov in ov2AllDependentObjectVersions)
    {
    	Console.WriteLine(ov.Id);
    }
    
    // Get newest ObjectVersions dependent on ov2 with different GenericObject
    // Output:
    // 3
    // 4
    Console.WriteLine("Get newest ObjectVersions dependent on ov2 with different GenericObject");
    IEnumerable<ObjectVersion> ov2NewestDependentObjectVersions =
    	dependencies
    	//.Where(d => d.ObjectVersion1.Id == ov2.Id || d.ObjectVersion2.Id == ov2.Id)
    	//.Select(d => d.ObjectVersion1)
    	//.Union(dependencies.Where(d => d.ObjectVersion1.Id == ov2.Id || d.ObjectVersion2.Id == ov2.Id)
    	//.Select(d => d.ObjectVersion2))
    	//.Where(o => o.Id != ov2.Id)
    	//.GroupBy(o => o.GenericObject.Id)
    	//.Select(g => g.OrderByDescending(o => o.Id).FirstOrDefault())
    	.SelectDependentObjectVersions(ov2.Id)
    	.SelectByLatestDistinctGenericObject()
    	.OrderBy(o => o.Id);
    foreach (ObjectVersion ov in ov2NewestDependentObjectVersions)
    {
    	Console.WriteLine(ov.Id);
    }
    
    // Get newest ObjectDependencies containing ov2 with different GenericObject
    // Output:
    // d2
    // d3
    Console.WriteLine("Get newest ObjectDependencies containing ov2 with different GenericObject");
    IEnumerable<ObjectDependency> ov2NewestDependencies =
    	dependencies
    	//.Where(d => d.ObjectVersion1.Id == ov2.Id || d.ObjectVersion2.Id == ov2.Id)
    	// ???
    	.SelectByLatestDistinctGenericObject(ov2.Id)
    	.OrderBy(d => d.Name);
    foreach (ObjectDependency dependency in ov2NewestDependencies)
    {
    	Console.WriteLine(dependency.Name);
    }
