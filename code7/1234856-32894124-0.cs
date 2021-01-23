    public class FooController : Controller
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        public FooController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment= hostingEnvironment;
        }
        
        public IActionResult Bar()
        {
            // this maps to /wwwroot folder
            var wwwroot = _hostingEnvironment.MapPath("");
           
            // this maps to /wwwroot/someFolder
            var someFolder=_hostingEnvironment.MapPath("someFolder");
            return View();
        }
    }
