    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class,
                    AllowMultiple = false, Inherited = true)]
    public sealed class ValidateHttpAntiForgeryTokenAttribute 
                                     : FilterAttribute, IAuthorizationFilter
    {
        public const string RequestVerificationTokenName = "RequestVerificationToken";
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext.HttpContext.Request.IsAjaxRequest())
            {
                ValidateRequestHeader(filterContext.HttpContext.Request);
            }
            else
            {
                AntiForgery.Validate();
            }
        }
        private static void ValidateRequestHeader(HttpRequestBase request)
        {
            string cookieToken = string.Empty;
            string formToken = string.Empty;
            var tokenValue = request.Headers[RequestVerificationTokenName];
            if (string.IsNullOrEmpty(tokenValue) == false)
            {
                string[] tokens = tokenValue.Split(':');
                if (tokens.Length == 2)
                {
                    cookieToken = tokens[0].Trim();
                    formToken = tokens[1].Trim();
                }
            }
            AntiForgery.Validate(cookieToken, formToken);
        }
