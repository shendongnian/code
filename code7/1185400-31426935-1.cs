    using Newtonsoft.Json;
    public class UserController : Controller
    {
        ...
        [HttpPost]
        public ActionResult Get(UsernameModel model)
        {
            // user service has code to search for users 
            // whose username equals to or is similar to model.Username
            var users = userService.GetUsersByUsername(model.Username);
            var response = new 
            {
                Users = users
            };
            return Content(JsonConvert.Serialize(response), "application/json");
        }
        ...
    }
