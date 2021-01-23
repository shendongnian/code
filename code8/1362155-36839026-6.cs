	from l in loc
	join bucket in (
        from l in loc
        group l by new DateTime(g.ReadTime.Year, g.ReadTime.Month, g.ReadTime.Day, g.ReadTime.Hour, g.ReadTime.Minute < 30 ? 0 : 30, 0) into g
        select g.Min(m => m.ReadTime)
    ) on l.ReadTime equals bucket
	select new LocationModel
	{
		Lng = l.FirstOrDefault().Lng,
		Lat = l.FirstOrDefault().Lat
	}
		
		
