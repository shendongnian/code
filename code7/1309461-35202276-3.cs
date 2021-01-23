    [RoutePrefix("Sync")]
    [Route("{action=ImageUploader}")] 
    public class ServiceController : Controller {
        //eg GET /Sync
        public ActionResult ImageUploader() {
            return View();
        }
    }
