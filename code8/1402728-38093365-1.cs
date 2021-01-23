	var result = ctx.SomeTable
		.Where(...whatever...)
		// Change: Do not project to an entity, but to an anonymous type
		.Select(x => new {
			// lots of properties
			// Change: Removed the Aggregate-part
			Adresses = m.RelatedMultipleWorks.Count == 0 ? 
				m.RelatedCity + " + " + m.RelatedCounty + " + " + m.RelatedDistrict + " + " +
				m.RelatedNeighborhood + " + " + m.RelatedStreet + " + " + m.Road :
				m.RelatedCity + " + " + m.RelatedCounty + " + " + m.RelatedDistrict + " + " +
				m.RelatedNeighborhood + " + " + m.RelatedStreet + m.RelatedRoad + " | ",
			// Added: New property for the aggregate-datasource
			RelatedAdresses = m.RelatedMultipleWorks
				.Select(z => 
					z.RelatedCity + " + " + z.RelatedCounty + " + " + z.RelatedDistrict + " + " +
					z.RelatedNeighborhood   + " + " + z.RelatedStreet + " + " + z.RelatedRoad
				)
			// other properties
		})
		// Added: Call AsEnumerable to stop translating to SQL
		.AsEnumerable()
		// Added: Project again, fairly simple since all properties are already ok, but now call the Aggregate
		.Select(x => new SomeEntity {
			// lots of properties		
			Adresses = Adresses + RelatedAdresses.Aggregate((current, next) => current + " | " + next)
			// other properties
		})
		.ToList();
