    public class LoadMenu : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var vb = filterContext.Controller.ViewBag;
            var menu = new List<MenuItem>();
            //I am hard coding to 2 items here. You may read it from your db table
            menu.Add(new MenuItem() { Text = "Home", TargetUrl = "Home/Index" });
            menu.Add(new MenuItem() { Text = "Careers", TargetUrl = "Home/Careers" });
            vb.Menus = menu;
        }
    }
