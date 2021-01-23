    public class YourController : Controller
    {
        private readonly ApplicationDbContext _db;
        public YourController()
        {
            _db = new ApplicationDbContext;
        }
        //Optional: Poor man's dependency injection for unit test
        //Also I highly recommend to have a look at IOC containers.
        public YourController(ApplicationDbContext db)
        {
            _db = db;
        }
    }
