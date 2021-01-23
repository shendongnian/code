    // the AOP filter, MVC built in feature
    public class NhSessionManagementAttribute : ActionFilterAttribute  
    {
        ... // some init stuff
    
        // here we start session
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            var session = SessionFactory.OpenSession();
            CurrentSessionContext.Bind(session);
            session.BeginTransaction();
        }
    
        // here we close it
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            var session = SessionFactory.GetCurrentSession();
            var transaction = session.Transaction;
            if (transaction != null && transaction.IsActive)
            {
                transaction.Commit();
            }
            session = CurrentSessionContext.Unbind(SessionFactory);
            session.Close();
        }
