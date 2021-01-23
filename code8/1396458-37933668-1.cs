        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            var session = SessionFactory.OpenSession();
            CurrentSessionContext.Bind(session);
        }
    
        protected void Application_EndRequest(object sender, EventArgs e)
        {
            var session = CurrentSessionContext.Unbind(SessionFactory);
            //commit transaction and close the session
        }
