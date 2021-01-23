static async Task Main(string[] args)
{
	var url = new Uri("wss://echo.websocket.org");
	var exitEvent = new ManualResetEvent(false);
	using (var client = new WebsocketClient(url))
	{
		client.MessageReceived.Subscribe(msg => Console.WriteLine($"Message: {msg}"));
		await client.Start();
		await client.Send("Echo");
		exitEvent.WaitOne();
	}
	Console.ReadLine();
}
Be sure to use `ManualResetEvent`. Otherwise it doesn't work.
