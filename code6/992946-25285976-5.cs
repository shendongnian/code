    public class PosteController : Controller
    {     
        [HttpPost]
        public ActionResult Index(CandidateModel Id)
        {
           TempData["Id"]=Id.val;
           return RedirectToAction ("Inscription","Candidate"); 
        }
    public class CandidateController : Controller
    {
        public ActionResult Inscription()
        {
          var id=TempData["Id"];
           ...........
        }
