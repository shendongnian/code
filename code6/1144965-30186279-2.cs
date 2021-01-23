    public class HomeController : Controller
    {
        IMapContext _context;
        public HomeController(IMapContext mapContext)
        {
            _context = mapContext;            
        }
        public ActionResult Index()
        {
            var x = (from c in _context.Area
                         select c.Name).ToArray();
           var y = (from c in _context.Area
                         select c.Pin).ToArray();
            var bytes = new Chart(width:500, height: 300)
            .AddSeries(
             chartType: "Column",
             xValue: x,
             yValues: y)
            .GetBytes("png");
            return File(bytes, "image/png");
        }
    }
