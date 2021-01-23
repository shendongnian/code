    public DatabaseAware()
	{
		XmlConfigurator.Configure();
		try
		{
			_logger.Info("Configuring NHibernate");
			_configuration = new Configuration().Configure();
			_sessionFactory = _configuration.BuildSessionFactory();
		}
		catch (Exception ex)
		{
			_logger.Fatal(ex);
			Assert.Fail(ex.Message);
		}
	}
