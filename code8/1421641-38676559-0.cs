    public class RegistrationController : Controller {
        // GET: Registration
        [Route("")]
        public ActionResult CreateUser(string platform) {
             return View("~/Views/Registration/CreateUser.cshtml", model: platform);
        }
    }
