    container.RegisterType<IDummyProxy, DummyProxy>(new InjectionFactory(c => 
    {
        var session = c.Resolve<DummySession>() // Ideally this would be IDummySession
        var sessionId = session.GetSessionId();
        
        return new DummyProxy(sessionId);
    }));
