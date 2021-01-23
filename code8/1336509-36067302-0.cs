	 var services = _ctx
		.Services 
		.Where(x => x.Facilities.Select(y => y.Id).Intersect(facilities).Any())
		.ToList();
	facilities
		.Select(id => new { 
			Id = id, 
			Services = services.Where(service => service.Facilities.Any(y => y.Id == id)).ToList()
		})
		.ToDictionary(x => x.Id, x => x.Services);
