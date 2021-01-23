    public class ClientController : Controller
    {
        public JsonResult CountryLookup()
        {
             var countries = new List<SearchTypeAheadEntity>
             {
                 new SearchTypeAheadEntity {ShortCode = "US", Name = "United States"},
                 new SearchTypeAheadEntity {ShortCode = "CA", Name = "Canada}
             };
             return Json(countries);
        }
    }
