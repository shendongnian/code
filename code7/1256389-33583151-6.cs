    List<Derp> nullDerps = new List<Derp>();
	nullDerps.Add(new Derp
	{
		IsNormal = null,
		SiteId = 5,
		SiteRegionId = 6
	});
	List<Derp> trueDerps = new List<Derp>();
	trueDerps.Add(new Derp
	{
		IsNormal = true,
		SiteId = 5,
		SiteRegionId = 6
	});
	List<Derp> falseDerps = new List<Derp>();
	falseDerps.Add(new Derp
	{
		IsNormal = false,
		SiteId = 5,
		SiteRegionId = 6
	});
	bool? firstNull = (from d in nullDerps
		where d.SiteRegionId == 6 && d.SiteId == 5
		select d.IsNormal).FirstOrDefault();
	bool? firstTrue = (from d in trueDerps
		where d.SiteRegionId == 6 && d.SiteId == 5
		select d.IsNormal).FirstOrDefault();
	bool? firstFalse = (from d in falseDerps
		where d.SiteRegionId == 6 && d.SiteId == 5
		select d.IsNormal).FirstOrDefault();
	bool anyNull = (from d in nullDerps
		where d.SiteRegionId == 6 && d.SiteId == 5
		select d.IsNormal).Any(a => a.HasValue && a.Value);
	bool anyTrue = (from d in trueDerps
		where d.SiteRegionId == 6 && d.SiteId == 5
		select d.IsNormal).Any(a => a.HasValue && a.Value);
	bool anyFalse = (from d in falseDerps
		where d.SiteRegionId == 6 && d.SiteId == 5
		select d.IsNormal).Any(a => a.HasValue && a.Value);
