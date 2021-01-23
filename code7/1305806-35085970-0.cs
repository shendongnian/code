    public void OnAuthorization(AuthorizationContext filterContext)
        {
            var request = filterContext.HttpContext.Request.HttpMethod;
            if (request != "GET")
            {
                if (filterContext == null)
                {
                    throw new ArgumentNullException("filterContext");
                }
                ValidateAction();
            }
        }
