      public class StatusCodesController : Controller
      {
        public IActionResult Index(string statusCode)
        {
          if(statusCode == null) statusCode = "";
          if(statusCode == "404") return View("Error404");
          return View("Index",statusCode);
        }
    
        public IActionResult Test404() { return StatusCode(404); }
        public IActionResult Test500() { return StatusCode(500); }
