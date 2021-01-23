    using System.Net.Http;
    using System.Web.Http.Controllers;
    using System.Web.Http.Filters;
    
    public class MakeWebApiFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            object data = "";
            if(actionContext.ActionArguments.TryGetValue("make", out data))
            {
                data = data.Replace("|", "/");;
                actionContext.ActionArguments["make"] = data;
            }
        }
    }
