    [RoutePrefix("Home")]
    public HomeController : Controller {
        //GET Home/Index
        //GET Home/Index/98
        [HttpGet]
        [Route("Index/{id?}")]
        public ActionResult Index(string id = null) {
            //When request to "Home/Index" then id will be null
            //otherwise it will be populated with the id
            if(!string.IsNullOrEmpty(id)) {
                //do something with the id
                var model = GetModel(id);
                return View(model);
            }
            return View(); 
        }
    }
