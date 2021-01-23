    var viewModel = reports.Select(c => new IdAndList{c.Id, c.PetList}).AsEnumerable()
		.GroupBy(c => c, new ReportIdAndPetListComparer())
		.Select(g => new ArmReportModel
		{
			PetList = g.Key.PetList,
			Pets = g.Count()
		});
