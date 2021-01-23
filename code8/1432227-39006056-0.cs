    var result = db.Definitions
        .GroupBy(e => e.NICK)
    	.ToDictionary(g => g.Key, g => g.Select(e => new ValueDescription
    	{
    		Value = e.VALUE,
    		Description = e.DESCRIPTION,
    	}).ToList());
