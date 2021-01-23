    var result = persons;
    if(chosenCountries.Any())
    {
    result = result.Where(p=>p.Countries.Any(c=>chosenCountries.Any(cc=>cc.Id == c.Id));
    }
    if(chosenRegions.Any())
    {
    result = result.Where(p=>p.Regions.Any(r=>chosenRegions.Any(cr=>cr.Id == r.Id));
    }
    return result.Distinct().ToList();
