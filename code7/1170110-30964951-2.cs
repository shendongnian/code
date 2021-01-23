    public class UsersController : Controller
    {
        [RouteParameterConstraint("id", RouteKeyHandling.CatchAll)]
        public IActionResult Users(long id)
        {
            return Json(new { name = "Example User" });
        }
        [RouteParameterConstraint("id", RouteKeyHandling.DenyKey)]
        public IActionResult Users()
        {
            return Json(new { list = new[] { "a", "b" } });
        }
    }
    public class RouteParameterConstraintAttribute : RouteConstraintAttribute
    {
        public RouteParameterConstraintAttribute(string routeParameterName, RouteKeyHandling keyHandling)
            : base(routeParameterName, keyHandling)
        {
        }
    }
