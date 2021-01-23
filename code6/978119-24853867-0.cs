public class ShowUserdetailsActionFilterAttribute : ActionFilterAttribute
{
   public override void OnActionExecuting(ActionExecutingContext filterContext)
   {
      base.OnActionExecuting(filterContext);
      using (Entities context = new Entities())
     {
       var userName = filterContext.HttpContext.User.Identity.Name;
     var u = context.Users.Where(x => x.DomainName == userName).FirstOrDefault();
        filterContext.Controller.TempData.Add("UserRole", user.Role);
     }
} 
