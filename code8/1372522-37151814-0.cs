	// First, get the Entity property, and invoke the getter
	var entity = message.GetType().GetProperty("Entity").GetValue(message);
	// Second, get the indexer property on it, and invoke the getter with an index(key)
	var empId = entity.GetType().GetProperty("Item").GetValue(entity, new[] { "EmpId" });
	
	Console.WriteLine("Name: " + empId);
