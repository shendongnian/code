    //StudentController.cs
    public class StudentController : Controller
    {
        private SessionContext db = new SessionContext();
        
        public ActionResult Index()
        {
            var result = db.People.Where(x => !string.IsNullOrEmpty(x.Education));
            return View(result.ToList());
        }
    }
