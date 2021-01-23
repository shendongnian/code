		var foo = new Foo();
		
		foo.AddRequest(1, new Request() { Response = new HttpResponse() });
		
		Request request;
		HttpResponse httpResponse;
		UdpResponse udpResponse;
		
		
		if (foo.TryGetRequest<HttpResponse>(1, out request, out httpResponse))
		{
			Console.WriteLine("1 is an HttpResponse"); 
		}
		
		if (!foo.TryGetRequest<UdpResponse>(1, out request, out udpResponse))
		{
			Console.WriteLine("1 is not a UdpResponse"); 
		}    
