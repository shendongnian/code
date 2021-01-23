     void Application_Start(object sender, EventArgs e)
            {
                // Code that runs on application startup
                Configuration config;
                config = WebConfigurationManager.OpenWebConfiguration("~");
                SessionStateSection SessionState = config.GetSection("system.web/sessionState") as SessionStateSection;
    
                if (SessionState != null)
                {
                    SessionState.Mode = System.Web.SessionState.SessionStateMode.InProc;// changes 
    
                    if (true/*condition*/)
                    {
                        SessionState.Cookieless = System.Web.HttpCookieMode.UseCookies;
                    }
                    else
                    {
                        SessionState.Cookieless = System.Web.HttpCookieMode.UseUri; // not sure about this one
                    }
                    config.Save();
                }
            }
