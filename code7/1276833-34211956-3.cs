    var viewModel = reports.Select(c => new {c.Id, c.PetList})
        .AsEnumerable()
        .Select(c => new IdAndList{c.Id, c.PetList})
		.GroupBy(c => c, new ReportIdAndPetListComparer())
		.Select(g => new ArmReportModel
		{
			PetList = g.Key.PetList,
			Pets = g.Count()
		});
