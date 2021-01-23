    public override void OnEntry(MethodExecutionArgs args)
    {
        ISessionFactory sessionFactory = ObjectFactory.GetInstance<ISessionFactory>();
        var session = SessionFactory.CurrentSession;
        // Store the session in the method context.
        args.MethodExecutionTag = session;
        // ...
    }
    public override void OnSuccess(MethodExecutionArgs args)
    {
        // Retrieve the session from the method context.
        var session = (ISession) args.MethodExecutionTag;
        // ...
    }
