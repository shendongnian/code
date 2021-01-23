    [RouteArea("AreaPrefix")]
    [RoutePrefix("RoutePrefix")]
    public class HomeController : Controller
    {
        ...
        [HttpGet]
        [Route("LoginAction")]
        public ActionResult Login() ....
