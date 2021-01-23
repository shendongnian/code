    using System.Web.Mvc;
    
    namespace FilePathInUrl.Controllers
    {
        public class FilePathController : Controller
        {
            // GET: FilePath
            public ActionResult Index(string filePath = "")
            {
                ViewBag.FilePath = filePath;
                return View();
            }
        }
    }
