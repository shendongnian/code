	public class Client
	{
		System.Net.WebRequest _webRequest = null;
		IDisposable _subscription = null;
		
		public Client()
		{
		    _webRequest = System.Net.WebRequest.Create("some url");
		    _webRequest.Method = "POST";
			
			const string keepAliveMessage = "{\"message\": {\"type\": \"keepalive\"}}";
		
			var keepAlives =
				from n in Observable.Interval(TimeSpan.FromSeconds(10.0))
				from u in Observable.Using(
					() => new StreamWriter(_webRequest.GetRequestStream()),
					sw => Observable.FromAsync(() => sw.WriteLineAsync(keepAliveMessage)))
				select u;
				
		    _subscription = keepAlives.Subscribe();
		}
	}
