	List<Person> groupedPeople = people
				
		// Group the list by id
		.GroupBy(p => p.SubscriptionId)  
		// Expand into a collection of anonymous objects with a group key 
		// set by the position in the group
		.SelectMany(g => g.Select((p, i) => new 
			{ GroupKey = i / 2, SubscriptionId = p.SubscriptionId, Person = p }))
		// Re-order the list by group key and subscription ID
		.OrderBy(x => x.GroupKey).ThenBy(x=> x.SubscriptionId)
		// Extract the original objects
		.Select(x => x.Person);
