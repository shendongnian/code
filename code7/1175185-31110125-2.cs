    public class ReferenceController : Controller
    {
        // GET: Reference
        [Authorize]
        public ActionResult Index()
        {
            var model = new WebApplication1.Models.Reference();
            return View("Index", model);
        }
    }
