    public class PosteController : Controller
    {
              
        [HttpPost]
        public ActionResult Index(CandidateModel Id)
        {
           TempData["Id"]=Id;
           return RedirectToAction ("Inscription","Candidate");
           
        }
    public class CandidateController : Controller
    {
              
        
        public ActionResult Inscription()
        {
          var id=TempData["Id"];
           ...........
           
        }
