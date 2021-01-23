    IEnumerable<A> GetMostRelatedAs( int numberOfAsToReturn )
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
                        singleA.ViewCount,
    					singleA
                    }
                )
            .OrderByDescending(x => x.ViewCount)
            .Take(numberOfAsToReturn)
            .ToList()
    		.Select(x => x.singleA);
    
        return results;
    }
