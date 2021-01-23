    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public class ValidateTokenAttribute : FilterAttribute, IAuthorizationFilter
    {
        public string VariableTokenKey = "__RequestVerificationToken";
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            try
            {
                if (filterContext.HttpContext.Request.IsAjaxRequest()) { this.ValidateRequestHeader(filterContext.HttpContext.Request); }
                else { AntiForgery.Validate(); }
            }
            catch
            {
                InvalidRequest(filterContext, "103", "", "Token not found.");
            }
        }
        private void ValidateRequestHeader(HttpRequestBase request)
        {
            string cookieToken = string.Empty;
            string formToken = string.Empty;
            string tokenValue = request.Headers[this.VariableTokenKey]; // read the header key and validate the tokens.
            if (!string.IsNullOrEmpty(tokenValue))
            {
                var antiForgeryCookie = request.Cookies[AntiForgeryConfig.CookieName];
                cookieToken = antiForgeryCookie != null ? antiForgeryCookie.Value : null;
            }
            AntiForgery.Validate(cookieToken, tokenValue); // this validates the request token.
        }
        private void InvalidRequest(AuthorizationContext filterContext, string errorCode, string sMessage, string eMessage)
        {
            if (filterContext.HttpContext.Request.IsAjaxRequest())
            {
                filterContext.Result = new JsonResult
                {
                    Data = new { ErrorCode = errorCode, Message = eMessage },
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                };
            }
            else
            {
                ViewDataDictionary viewData = new ViewDataDictionary();
                viewData.Add("ShortMessage", "Access denied.");
                viewData.Add("Message", "Anti forgery token not found.");
                filterContext.Result = new ViewResult { MasterName = "", ViewName = "Error", ViewData = viewData };
            }
        }
    }
