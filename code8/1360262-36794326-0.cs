    SessionFactory _factory;
    public NHibernateRegistry()    
    {
        _factory = config.BuildSessionFactory();
        For<IRepository>.Use<Repository>()
        For<ISession>.Use(() => _factory.OpenSession());
    }
