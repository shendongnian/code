    // Note: The GetContext method blocks while waiting for a request. 
    HttpListenerContext context = listener.GetContext();
    HttpListenerRequest request = context.Request;
    Console.WriteLine("URL: {0}", request.Url.OriginalString);
    Console.WriteLine("Raw URL: {0}", request.RawUrl);
    Console.WriteLine("Query: {0}", request.QueryString);
    // Obtain a response object.
    HttpListenerResponse response = context.Response;
