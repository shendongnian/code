    namespace PhoenixHR.Global
    {
        public class SessionMissingRedirectHttpModule : IHttpModule
        {
            private const string LAYOUTS_SUBFOLDER = "/PhoenixHR.Global";
            private const string START_PAGE = "/start.aspx";
            public void Dispose()
            {
            }
            public void Init(HttpApplication context)
            {
                context.PostAcquireRequestState += context_PostAcquireRequestState;
            }
            void context_PostAcquireRequestState(object sender, EventArgs e)
            {
                // get required contexts
                SPHttpApplication application = (SPHttpApplication)sender;
                HttpContext context = application.Context;
                HttpSessionState session = context.Session;
                if (session == null)
                    return;
                if (session["TPL"] != null)
                    return;
                // get SharePoint context and current SPWeb.
                SPContext sharepointContext = SPContext.GetContext(context);
                SPWeb currentWeb = sharepointContext.Web;
                // build a url to the redirect page.
                string layoutsFolder =
                    SPUtility.GetLayoutsFolder(currentWeb);
                string url = string.Format("{0}/{1}{2}{3}", currentWeb.Url, layoutsFolder, LAYOUTS_SUBFOLDER, START_PAGE);
                // prevent redirection loop
                if (context.Request.Url.AbsoluteUri.Equals(url, StringComparison.InvariantCultureIgnoreCase))
                    return;
                SPUtility.Redirect(url, SPRedirectFlags.Trusted, context);
            }
        }
    }
