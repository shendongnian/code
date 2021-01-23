    public class ObsoleteApiAttribute : System.Web.Http.Filters.ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            var response = actionContext.Request.CreateResponse(System.Net.HttpStatusCode.BadRequest, "Update your app");
            actionContext.Response = response;
        }
    }
