    public class EtlProceduresNamesAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
             //you can add some caching here
             filterContext.Controller.ViewBag.EtlProcedures = (new MIPortal.Models.EtlProcedure()).GetType().GetProperties()).Select(item => item.Name)).ToList();
        } 
    }
