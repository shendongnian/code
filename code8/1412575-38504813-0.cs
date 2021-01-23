     protected void Application_PreRequestHandlerExecute()
        {
            HttpSessionState session = HttpContext.Current.Session;
            if (session == null)
                return;
            IUser user = (session[HttpSecurityContext.SECURITY_CONTEXT_KEY] as IUser) ?? CreateUser();
            securityContext.SetCurrent(user);
        }
        protected void Application_PostRequestHandlerExecute()
        {
            HttpSessionState session = HttpContext.Current.Session;
            if (session == null) return;
            session[HttpSecurityContext.SECURITY_CONTEXT_KEY] = securityContext.Current;
        }
     private IUser CreateUser()
        {
            IUserLocation location = LocateUser();
            IUser user = Common.Security.User.CreateAnonymous(location);
            SetupUserPreferences(user);
            return user;
        }
