    public class PosteController : Controller
    {     
        [HttpPost]
        public ActionResult Index(CandidateModel Id)
        {
           return RedirectToAction ("Inscription","Candidate",new{ dropdownval=Id.val,Id });  
        }
    public class CandidateController : Controller
    {
        public ActionResult Inscription(int? dropdownval)
        {
           ...........
        }
