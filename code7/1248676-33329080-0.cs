	HttpListener listener = new HttpListener();
	listener.Prefixes.Add("http://*:5555/");
	listener.Start();
	listener.BeginGetContext(ar =>
	{
		HttpListener l = (HttpListener)ar.AsyncState;
		HttpListenerContext context = l.EndGetContext(ar);
		context.Response.Headers.Clear();
		context.Response.SendChunked = false;
		context.Response.StatusCode = 200;
		context.Response.Headers.Add("Server", String.Empty);
		context.Response.Headers.Add("Date", String.Empty);
		context.Response.Close();
	}, listener);
