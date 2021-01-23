    [RoutePrefix("Sync")]
    [Route("{action=ImageUploader}")] 
    public class ServiceController : Controller {
        //eg GET /Sync
        [Route("")]
        public ActionResult ImageUploader() {
            return View();
        }
    }
