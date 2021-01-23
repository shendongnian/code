    public class PesonController : Controller
    {
        [HttpGet]
        [Route("~/")]
        [Route("person/search")]
        public ActionResult Search()
        {
            PersonSearchViewModel psvm = new PersonSearchViewModel();
            return View(psvm);
        }
    }
