    public IConnectionProvider GetProvider(NHibernate.Cfg.Configuration cfg)
    {
        var type = Type.GetType(cfg.GetProperty(Environment.ConnectionProvider));
        return (IConnectionProvider) Activator.CreateInstance(type);
    }
