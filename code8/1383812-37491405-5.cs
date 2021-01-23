    context.Continents.Where(x => !x.IsDeleted)
    		.Select(x => new {Continents = x,
    		                  Countries = x.Countries.Where(y => !y.IsDeleted),
    						  Cities = x.Countries.Where(y => !y.IsDeleted)
    							        .SelectMany(y => y.Cities).Where(y => !y.IsDeleted)
    				})
    		.ToList()
    		.Select(x => x.Continents) // select only continents
    		.ToList();
