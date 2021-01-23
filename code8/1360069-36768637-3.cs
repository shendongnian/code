	//context is an Entity Framework database context - see 
	//https://www.asp.net/mvc/overview/getting-started/database-first-development/creating-the-web-application
	var query = context.MyTable
		.Where(c => c.Key == todo.Key);
	if (!string.IsNullOrWhiteSpace(someValueToCheck))
	{
		//This where is use in conjunction to the previous WHERE.
		query = query.Where(c => c.SomeOtherField == someValueToCheck);
	}
	
	//Get the single thing we want to update.
	var thingToUpdate = query.First();
	
	//Update the values.
	thingToUpdate.Name = table.Name;
	thingToUpdate.table.IsComplete = table.IsComplete;
	//We can save to context to apply these results.
	context.SaveChanges();
