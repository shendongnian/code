    var list = 
    	Repository
    	.GetAll()
    	.GroupBy(a => a.Animals)
    	.Select(grouping => new {
    		name = grouping.Key.Name,
    		id = grouping.Key.Id,
    		data = grouping.Select(x => x)
    	}).ToList();
