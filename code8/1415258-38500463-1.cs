    public class LoginModel {
        public string User {get; set;}
        public string Pass {get; set;}
    }
    public class HomeController : Controller
    {
        ...
    
        [HttpPost]
        public JsonResult PostData([FromBody] LoginModel model)
        {
           ...
        }
    }
