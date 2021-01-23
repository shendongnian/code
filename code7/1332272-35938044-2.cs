    	public class AspnetCoreAndXUnitPrimeShould: IClassFixture<CompositionRootFixture>
	{
		private readonly TestServer _server;
		private readonly HttpClient _client;
		private readonly CompositionRootFixture _fixture;
		public AspnetCoreAndXUnitPrimeShould(CompositionRootFixture fixture) 
		{
			// Arrange
			_fixture = fixture;
			_server = new TestServer(TestServer.CreateBuilder(null, app =>
			{
				app.UsePrimeCheckerMiddleware();
			},
				services =>
				{
					services.AddSingleton<IPrimeService, NegativePrimeService>();
					services.AddSingleton<IPrimeCheckerOptions>(_ => new AlternativePrimeCheckerOptions(_fixture.Path));
				}));
			_client = _server.CreateClient();
		}
