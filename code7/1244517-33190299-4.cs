    public class JsonDemo
    {
        public bool Bool { get; set; }
    }
    
    public class DemoController : Controller
    {
        [HttpPost]
        public ActionResult Demo(JsonDemo demo)
        {
            var demoBool = demo.Bool;
    
            return Content(demoBool.ToString());
        }
    }
