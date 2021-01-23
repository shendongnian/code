    public class Movies2Controller : Controller
    {
        private Jess_MoviesEntities db = new Jess_MoviesEntities();
        public ActionResult Index()
        {
            return View(db.Movies.ToList());
        }
        public ActionResult OneMovie(int id)
        {
            return View();
        }
        public ActionResult Details(int id)
        {
            //get model from database
            return PartialView(db.Movies.First(x => x.ID == id));
        }
    }
