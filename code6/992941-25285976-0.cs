    public class PosteController : Controller
    {
              
        [HttpPost]
        public ActionResult Index(CandidateModel Id)
        {
          
           return RedirectToAction ("Inscription","Candidate",new{ Id=Id });
           
        }
    public class CandidateController : Controller
    {
              
        
        public ActionResult Inscription(int? Id)
        {
          
           ...........
           
        }
