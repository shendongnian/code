    public class FooController : Controller
    {
        public IHttpActionResult Get(FooCriteria criteria)
        {          
            return new OkResult(new HttpRequestMessage());
        }
        public ActionResult Index()
        {           
            return View();
        }
        
        public class FooCriteria
        {
            public string Baz { get; set; }
            public Location Location { get; set; }
        }
        public class Location
        {
            public double Latitude { get; set; }
            public double Longitude { get; set; }
        }
    }
