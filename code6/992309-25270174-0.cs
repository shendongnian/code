    var query = context.clients.AsQueryable();
    
    if (parameter != -1)
	    query = query.Where(a=>a.regionID == parameter);
	
	
    var result = query
        .OrderBy(x => x.Name )
	    .Select(x => new
        {
           x.clientID, x.businessName
        });
    
