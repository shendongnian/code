    public class FileProtectionHandler : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            switch (context.Request.HttpMethod)
            {
                case "GET":
                {
                    // Is the user logged-in?
                    if (!context.User.Identity.IsAuthenticated)
                    {
                        FormsAuthentication.RedirectToLoginPage();
                        return;
                    }
                    string requestedFile = context.Server.MapPath(context.Request.FilePath);
                    // Verify the user has access to the User role.
                    if (context.User.IsInRole("Security Alerts - Admin"))
                    {
                        SendContentTypeAndFile(context, requestedFile);
                    }
                    else
                    {
                        // Deny access, redirect to error page or back to login page.
                        context.Response.Redirect("~/User/AccessDenied.aspx");
                    }
                    break;
                }
            }
        }
        public bool IsReusable { get; private set; }
        private HttpContext SendContentTypeAndFile(HttpContext context, String strFile)
        {
            context.Response.ContentType = GetContentType(strFile);
            context.Response.TransmitFile(strFile);
            context.Response.End();
        
            return context;
        }
        
        private string GetContentType(string filename)
        {
            // used to set the encoding for the reponse stream
            string res = null;
            FileInfo fileinfo = new FileInfo(filename);
        
            if (fileinfo.Exists)
            {
                switch (fileinfo.Extension.Remove(0, 1).ToLower())
                {
                    case "pdf":
                    {
                        res = "application/pdf";
                        break;
                    }
                }
        
                return res;
            }
        
            return null;
        }
    }
