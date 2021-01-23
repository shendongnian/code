	from l in loc
	join bucket in (loc.GroupBy(g => g.ReadTime.Minute < 30 
					  ? new DateTime(g.ReadTime.Year, g.ReadTime.Month, g.ReadTime.Day, g.ReadTime.Hour, 0, 0)
					  : new DateTime(g.ReadTime.Year, g.ReadTime.Month, g.ReadTime.Day, g.ReadTime.Hour, 30, 0))
				    .Select(g => g.Min(m => m.Id))) on l.Id equals bucket
	select new LocationModel
	{
		Lng = l.FirstOrDefault().Lng,
		Lat = l.FirstOrDefault().Lat
	}
		
