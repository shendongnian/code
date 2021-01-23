    var query = db.OrderItems
    	.SelectMany(orderItem => orderItem.NominalRoutings)
    	.GroupBy(routing => routing.Operation.AreaSpecification.Title)
    	.Select(g => new
    	{
    		AreaTitle = g.Key,
    		Routing = g.OrderBy(e => e.PlanedDate).FirstOrDefault()
    	})
    	.Select(e => new
    	{
    		e.Routing.OrderItem.Id,
    		e.AreaTitle,
    		e.Routing.Operation.Code,
    		e.Routing.PlanedDate
    	});
