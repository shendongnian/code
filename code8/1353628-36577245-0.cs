    public class Filter
    {
        public int CountryID;
        public int RegionID;
        public int SiteID;
    }
    
    var filter = new List<Filter>();
    
    var result = persons.Where(p => 
           filter.Any(f => p.Countries.Any(c => c.ID == f.CountryID) &&
                      f => p.Regions.Any(r => r.ID == f.RegionID) &&
                      f => p.Sites.Any(s => s.ID == f.SiteID)));
