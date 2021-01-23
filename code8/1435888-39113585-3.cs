	const string WsEndpoint = "wss://push.planetside2.com/streaming?environment=ps2&service-id=s:quicktesting";
	Console.WriteLine("Defining Observable:");
	IObservable<EventPattern<WebSocketSharp.MessageEventArgs>> observable =
		Observable
			.Using(
				() =>
				{
					var ws = new WebSocketSharp.WebSocket(WsEndpoint);
					ws.Connect();
					return ws;
				},
				ws =>
					Observable
						.FromEventPattern<EventHandler<WebSocketSharp.MessageEventArgs>, WebSocketSharp.MessageEventArgs>(
							handler => ws.OnMessage += handler,
							handler => ws.OnMessage -= handler));
	Console.WriteLine("Subscribing to Observable:");
	IDisposable subscription = observable.Subscribe(ep =>
	{
		Console.WriteLine("Event Recieved");
		Console.WriteLine(ep.EventArgs.Data);
	});
	
	Console.WriteLine("Writing to Source:");
	
	using (var source = new WebSocketSharp.WebSocket(WsEndpoint))
	{
		source.Connect();
		source.Send("test");
	}
