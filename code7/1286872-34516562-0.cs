    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    namespace LapisRealmv2.Controllers
    {
        public class Visited : ActionFilterAttribute
        {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (!filterContext.HttpContext.Request.Cookies.AllKeys.Contains("Visited"))
            {
                filterContext.Result = new RedirectResult("~/Welcome/Index");
                return;
            }
            base.OnActionExecuting(filterContext);
        }
    }
