    public class HomeController : Controller
    {
        private DbContext db;
    
        public HomeController(DbContext db)
        {
            this.db = db;
        }
    
        public ActionResult Index()
        {
            // Do stuff with context
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
                db.Dispose();
            base.Dispose(disposing);
        }
    } 
