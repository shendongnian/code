    public DatabaseAware()
	{
		XmlConfigurator.Configure();
		_logger.Info("Configuring NHibernate");
		_configuration = new Configuration().Configure();
		_sessionFactory = _configuration.BuildSessionFactory();
	}
