	var query =
		from r in context.StaffingResourceDatas
		where r.EmployeeId != null && !exclusionList.Contains(r.ResourceTitleId)
		select new ChartResourceModel
		{
			ResourceId = r.ResourceId,
			Division = r.ResourceDivision,
			Type = r.ResourceType,
			Dates = dates.Select(d => new ChartDateModel
			{
				Date = d,
				Available = context.StaffingForecasts.Where(f => 
                    f.ResourceId == r.ResourceId && f.Date == d).Sum(f => f.Hours) < 24
			}).ToList()
		};
	var sqlQuery = query.ToString();
	var result = query.ToList();
