    [AllowAnonymous]
    public class ErrorController : Controller {
        // GET: Error
        public ActionResult NotFound() {
            Response.StatusCode = (int)System.Net.HttpStatusCode.NotFound;
            Response.TrySkipIisCustomErrors = true;
            HttpContext.Response.StatusCode = (int)System.Net.HttpStatusCode.NotFound;
            HttpContext.Response.TrySkipIisCustomErrors = true;
            return View();
        }
        public ActionResult Error() {
            Response.StatusCode = (int)System.Net.HttpStatusCode.InternalServerError;
            Response.TrySkipIisCustomErrors = true;
            return View();
        }
    }
