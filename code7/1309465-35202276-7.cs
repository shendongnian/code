    public class ServiceController : Controller {
        //eg GET /Sync
        [Route("~/Sync")]
        public ActionResult ImageUploader() {
            return View();
        }
    }
