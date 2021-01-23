    public void ProcessRequest(HttpContext context)
        {
            IAuthenticationManager authManager = context.GetOwinContext().Authentication;
            if (string.IsNullOrEmpty(context.Request.QueryString[CallBackKey]))
            {
                string providerName = context.Request.QueryString["provider"] ?? "Google";//I have multiple providers so checking if its google
                RedirectToProvider(context, authManager, providerName);
            }
            else
            {
                ExternalLoginCallback(context, authManager);
            }
        }
