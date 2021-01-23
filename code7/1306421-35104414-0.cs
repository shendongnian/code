    using(var ctx = new EntitiesContext())
    {
    	                              // GROUP By name
    	var bookCountByTag = ctx.Tags.GroupBy(t => t.Name)
    	                        .Select(t2 => new { 
    								// SELECT the key (tag name)
    							    t2.Key, 
    								
    								// "GroupBy" has many result, so use SelectMany
    							    Count = t2.SelectMany(t3 => t3.book)
    								          .Distinct()
    										  .Count()})
    			                .ToList();
    }
