        public static String sessionkey = "current.session";
        public static ISession CurrentSession
        {
            get { return (ISession)HttpContext.Current.Items[sessionkey]; }
            set { HttpContext.Current.Items[sessionkey] = value; }
        }
        protected void Application_BeginRequest()
        {
            CurrentSession = SessionFactory.OpenSession();
        }
        protected void Application_EndRequest()
        {
            if (CurrentSession != null)
                CurrentSession.Dispose();
        }
