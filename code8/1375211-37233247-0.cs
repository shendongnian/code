	var client = new GoogleApiClient.Builder(Application.Context)
	                                .AddApi(GamesClass.API)
	                                .AddScope(GamesClass.ScopeGames)
	                                .Build();
	Task.Run(() => {
		client.BlockingConnect();
		System.Diagnostics.Debug.WriteLine(client.IsConnected);
	});
