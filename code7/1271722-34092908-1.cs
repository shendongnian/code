		public static void ConfigureAndStartBus(IWindsorContainer container)
		{
			_RegisterBus(container, "ConnectionStringA" "BusA");
			_RegisterBus(container, "ConnectionStringB" "BusB");
		}
		private static void _RegisterBus(IWindsorContainer container, string connectionString, string busName)
		{
			var bus = Configure.With(new BuiltinContainerAdapter())
				.Transport(tc => tc.UseSqlServerInOneWayClientMode(connectionString))
				.Subscriptions(sc => sc.StoreInSqlServer(connectionString, "RebusSubscriptions"))
				.CreateBus()
				.Start();
			container.Register(
				Component.For<IBus>()
					.Named(busName)
					.LifestyleSingleton()
					.Instance(bus));
		}
