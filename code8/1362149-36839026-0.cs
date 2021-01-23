	from p in loc
	join bucket in (loc.GroupBy(l => l.ReadTime.Minute < 30 
					  ? new DateTime(l.ReadTime.Year, l.ReadTime.Month, l.ReadTime.Day, l.ReadTime.Hour, 0, 0)
					  : new DateTime(l.ReadTime.Year, l.ReadTime.Month, l.ReadTime.Day, l.ReadTime.Hour, 30, 0))
				    .Select(g => g.Min(m => m.ReadTime))) on p.ReadTime equals bucket
	select new LocationModel
	{
		Lng = p.FirstOrDefault().Lng,
		Lat = p.FirstOrDefault().Lat
	}
		
		
