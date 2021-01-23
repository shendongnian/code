    public class StuffController : Controller
    {
        private MyDbContext _db;
        private StuffRepository _repo;
        public StuffController()
        {
            _db = new MyDbContext();
            _repo = new StuffRepository(_db);
        }
        // ...
        public ActionResult Details(int id)
        {
            var model = _repo.ReadDetails(id);
            // ...
            return View(model);
        }
        protected override void Dispose(bool disposing)
        {
            _db.Dispose();
            base.Dispose(disposing);
        }
    }
