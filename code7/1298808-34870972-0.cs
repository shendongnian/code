    public class HomeController : Controller
    {
        private IHostingEnvironment _environment;
    
        public HomeController(IHostingEnvironment environment)
        {
            _environment = environment;
        }
        public IActionResult Index()
        {
            return View();
        }
            
        [HttpPost]
        public async Task<IActionResult> Index(ICollection<IFormFile> files)
        {
            var uploads = Path.Combine(_environment.WebRootPath,"uploads"); 
            foreach(var file in files)
            {
                if(file.Length > 0)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    await file.SaveAsAsync(Path.Combine(uploads,fileName));
                }
            return View();
            }
        }    
    }
