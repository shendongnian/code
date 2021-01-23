    IEnumerable<dynamic> GetMostRelatedAs( int numberOfAsToReturn )
    {
    	var results = this.context.A
    		.GroupJoin(
    			this.context.B,
    			a => a.ID,
    			b => b.A.ID,
    			(singleA, multipleBs) => new {
    					// this is the projection, so take here what you want
    					numberOfBs = multipleBs.Count(),
    					name = singleA.Name,
    					singleA.ViewCount
    				}
    			)
    		.OrderByDescending(x => x.ViewCount)
    		.Take(numberOfAsToReturn)
    		.ToList();
    		
    		// here you can use automapper to project to a type that you can use
    		// So you could add the following method calls after the ToList()
    		// .Project(this.mappingEngine)
    		// .To<ClassThatRepresentsStructure>()
    		
    		// The reason you don't map before the ToList is that you are already doing a projection with that anonymous type.
    	return results;
    }
