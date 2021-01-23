    public class UsersController : Controller
    {
        [RouteParameterConstraint("id", ShouldAppear=true)]
        public IActionResult Users(long id)
        {
            return Json(new { name = "Example User" });
        }
        [RouteParameterConstraint("id", ShouldNotAppear=true)]
        public IActionResult Users()
        {
            return Json(new { list = new[] { "a", "b" } });
        }
    }
    public class RouteParameterConstraintAttribute : Attribute, IActionConstraint
    {
        private routeParameterName;
        public RouteParameterConstraintAttribute(string routeParameterName)
        {
            this.routerParamterName = routerParameterName;
        }
        public int Order => 0;
        public bool ShouldAppear {get; set;}
        public bool ShouldNotAppear {get; set;}
        public bool Accept(ActionConstraintContext context)
        {
            if(ShouldAppear) return context.RouteContext.RouteData.Values["country"] != null;
            if(ShouldNotAppear) return context.RouteContext.RouteData.Values["country"] == null;
            return true;
        }
    }
