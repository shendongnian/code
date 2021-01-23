    [Route("[AreaPrefix]/[ControllerPrefix]")]
    public class HomeController : Controller
    {
        ...
        [HttpGet("LoginAction")]
        public IActionResult Login() {
