    public class YourController : Controller
    {
        private readonly ApplicationDbContext _db;
        public YourController()
        {
            _db = new ApplicationDbContext;
        }
    }
