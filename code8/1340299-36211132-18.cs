    using NHibernate.Cfg;
    // ...
	var cfg = new Configuration();
	cfg.LinqToHqlGeneratorsRegistry<ExtendedLinqToHqlGeneratorsRegistry>();
    // And build the session factory using this configuration.
