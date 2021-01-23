    public class LocalizationModule : IHttpModule
    {
        public void Dispose()
        {
        }
    
        public void Init(HttpApplication context)
        {
            context.BeginRequest += new EventHandler(context_BeginRequest);
        }
    
        void context_BeginRequest(object sender, EventArgs e)
        {
            // check if user is authenticated
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                var username = HttpContext.User.Identity.Name;
                /* 
                   Your code to read user's culture name from the profile and
                   put it in "lang" variable
                */
                var culture = new System.Globalization.CultureInfo(lang);
                Thread.CurrentThread.CurrentCulture = culture;
                Thread.CurrentThread.CurrentUICulture = culture;
            }
        }
    }
