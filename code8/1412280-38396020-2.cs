    //Some initializing code for testing
    var timeValue = DateTime.Now;
    List<Rates> rates = new List<Rates>()
    {
    	new Rates { CheckInDate = timeValue, websiteId = 1, price = 1 },
    	new Rates { CheckInDate = timeValue, websiteId = 1, price = 2 },
    	new Rates { CheckInDate = timeValue, websiteId = 2, price = -1 },
    	new Rates { CheckInDate = timeValue, websiteId = 2, price = 2 },
    	new Rates { CheckInDate = timeValue, websiteId = 3, price = -1 },
    	new Rates { CheckInDate = timeValue, websiteId = 3, price = -1 },
    };
    
    //The actual relevant code
    var result = rates.GroupBy(item => new { item.websiteId, item.CheckInDate })
    				  .Select(grp => grp.Any(item => item.price != -1) ?
    					  grp.Where(item => item.price != -1).OrderBy(item => item.price).First() :
    					  grp.First())
    				  .ToList();
