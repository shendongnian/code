    private static readonly object syncObject = new Object();
        
    public static ISession GetCurrentSession()
    {   
         lock (syncObject)
         {
             HttpContext context = HttpContext.Current;
             ISession currentSession = context.Items[CURRENT_NHIBERNATE_SESSION_KEY] as ISession;
             if (currentSession == null)
             {
                 currentSession = sessionFactory.OpenSession();
             }
             context.Items[CURRENT_NHIBERNATE_SESSION_KEY] = currentSession;    
             return currentSession;
         }
    }
