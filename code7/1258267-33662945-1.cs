		var noduplicates = products.GroupBy(x => new {x.Application, x.ExternalDisplayId})
			.Select(y => y.OrderByDescending(x => x.CreateDate).First())
			.ToList()
			.Distinct(new ApplicationExternalDisplayIdComparer())
			.GroupBy(x => new {x.Application, x.ExternalID})
			.Select(y => y.OrderByDescending(x => x.CreateDate).First())
			.ToList()
			.Distinct(new ApplicationExternalIDComparer());
