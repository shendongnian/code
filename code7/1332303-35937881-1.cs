    			_server = new TestServer(TestServer.CreateBuilder(null, app =>
			{
				app.UsePrimeCheckerMiddleware();
			},
				services =>
				{
					services.AddSingleton<IPrimeService, NegativePrimeService>();
					services.AddSingleton<IPrimeCheckerOptions, PrimeCheckerOptions>();
				}));
