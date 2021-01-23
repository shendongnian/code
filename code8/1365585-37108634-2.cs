        private static void RedirectIfAdmin(CookieApplyRedirectContext context)
        {
            // If Url contains 
            Uri absoluteUri;
            if (Uri.TryCreate(context.RedirectUri, UriKind.Absolute, out absoluteUri))
            {
                string path = context.Request.PathBase + context.Request.Path + context.Request.QueryString;
                if (path.Contains("/administration")) { 
                    context.RedirectUri = "/administration/login.aspx" +
                    new QueryString(context.Options.ReturnUrlParameter, context.Request.Uri.AbsoluteUri);
                }
            }
            context.Response.Redirect(context.RedirectUri);
        }
