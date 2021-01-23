    var routeList = db.Clients
    				.Where(p => p.ClientName.StartsWith(term))
    				.OrderBy(p => p.ClientName)
    				.Select(p => new { id = p.ClientID, clientName = p.ClientName })
    				.ToList();
