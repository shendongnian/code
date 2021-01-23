        namespace TestingUrl.Controllers
        {
            [RoutePrefix("MyController")] // <- Put a special url name for the controller
            public class AnotherController : Controller
            {
                [Route("MyFunction/{name}/{city}")] // <- A special name for the action and the two parameters
                [HttpGet]
                public ActionResult AnotherIndex(string name, string city)
                {
                    ViewBag.Name = name;
                    ViewBag.City = city;
                    return View();
                }
            }
        }
