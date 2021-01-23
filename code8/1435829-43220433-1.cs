	protected override IEnumerable<ServiceInstanceListener> CreateServiceInstanceListeners()
	{
		return new ServiceInstanceListener[]
		{
			new ServiceInstanceListener(serviceContext =>
				new WebListenerCommunicationListener(serviceContext, "ServiceEndpoint", (url, listener) =>
				{
					ServiceEventSource.Current.ServiceMessage(serviceContext, $"Starting WebListener on {url}");
					var environment = FabricRuntime.GetActivationContext()
						?.GetConfigurationPackageObject("Config")
						?.Settings.Sections["Environment"]
						?.Parameters["ASPNETCORE_ENVIRONMENT"]?.Value;
					return new WebHostBuilder().UseWebListener()
						.ConfigureServices(
							services => services
								.AddSingleton<StatelessServiceContext>(serviceContext))
						.UseContentRoot(Directory.GetCurrentDirectory())
						.UseStartup<Startup>()
						.UseEnvironment(environment)
						.UseApplicationInsights()
						.UseUrls(url)
						.Build();
				}))
		};
	}
