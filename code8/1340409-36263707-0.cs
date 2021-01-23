    public List<Region> GetRegionsAndSubRegions(){
    var regions = Context.Regions.Where(r => condition);
    var anonRegions = regions.Select(r => new {
                                      RegionName = r.RegionName,
                                      RegionId = r.RegionId
                                  }).ToList();
    var lightRegions = anonRegions.Select(r => new Region{
                                      RegionName = r.RegionName,
                                      RegionId = r.RegionId
                                  }).ToList();
    }
