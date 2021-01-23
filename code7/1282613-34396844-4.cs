    public class CustomJsonAuthorizationFilter : IAsyncAuthorizationFilter
    {
        private AuthorizeFilter wrappedFilter;
        public CustomJsonAuthorizationFilter(AuthorizeFilter wrappedFilter)
        {
            this.wrappedFilter = wrappedFilter;
        }
        public async Task OnAuthorizationAsync(Microsoft.AspNet.Mvc.Filters.AuthorizationContext context)
        {
            await this.wrappedFilter.OnAuthorizationAsync(context);
            if(context.Result != null && IsAjaxRequest(context))
            {
                context.Result = new JsonResult(new
                {
                    success = false,
                    error = "You must be signed in."
                });
            }
            return;
        }
        //This could be an extension method of the HttpContext/HttpRequest
        private bool IsAjaxRequest(Microsoft.AspNet.Mvc.Filters.AuthorizationContext filterContext)
        {
            return filterContext.HttpContext.Request.Headers["X-Requested-With"] == "XMLHttpRequest";
        }
    }
