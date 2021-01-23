    var countryIdsToCheck = new List<int> { 1,3,5 };
    var regionIdsToCheck = new List<int> { 6,8 };
    var siteIdsToCheck= new List<int> { 35 };
    var result = yourDbContext.Persons;
    if(countryIdsToCheck.Any())
    {
      result= result.Where(s=>s.Countries.Any(x=>countryIdsToCheck.Contains(x.Id));
    }
    if(regionIdsToCheck.Any())
    {
      result= result.Where(s=>s.Regions.Any(y=>regionIdsToCheck .Contains(y.Id));
    }
    if(siteIdsToCheck.Any())
    {
      result= result.Where(s=>s.Sites.Any(z=>siteIdsToCheck.Contains(z.Id));
    }
    var finalResult=result.ToList();
