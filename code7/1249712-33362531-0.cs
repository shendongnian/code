	var model =
		SessionObjectsMSurvey.ContractList
		.Where(y => y.ContractTitle.ToUpper().Contains(upper))
		.GroupBy(g => new 
		{
			g.BriefTitle,
			g.ContractId
		})
		.Select(
			x => new
			{
				label = x.Key.BriefTitle,                 // Here
				id = x.Key.ContractId.ToString()          // And here
			}).Take(20);
