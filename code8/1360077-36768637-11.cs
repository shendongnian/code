	//The context you have setup for the ERP database.
	using (var db = new ERPContext()) 
	{ 
	
		//db is an Entity Framework database context - see 
		//https://msdn.microsoft.com/en-au/data/jj206878.aspx
		var query = db.MyTable
			.Where(c => c.Key == todo.Key);
		if (!string.IsNullOrWhiteSpace(someValueToCheck))
		{
			//This where is used in conjunction to the previous WHERE,
			//so it's more or less a WHERE condition1 AND condition2 clause.
			query = query.Where(c => c.SomeOtherField == someValueToCheck);
		}
		
		//Get the single thing we want to update.
		var thingToUpdate = query.First();
		
		//Update the values.
		thingToUpdate.Name = table.Name;
		thingToUpdate.IsComplete = table.IsComplete;
		//We can save the context to apply these results.
		db.SaveChanges();
		
	}
