    public class HomeController : Controller
    {
        private IFileProvider _fileProvider;
        public HomeController(IFileProvider fileProvider)
        {
            _fileProvider = fileProvider;
        }
        public IActionResult Index()
        {
            DateTimeOffset lastModifiedDate = _fileProvider.GetFileInfo(@"Views\Home\Index.cshtml").LastModified;
            // use it wisely...
            return View();
        }
