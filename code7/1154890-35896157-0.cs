    HTTPListener httpListener = new HttpListener();
    httpListener.Prefixes.Add("http://localhost/");
    httpListener.Start();
    HTTPListenerContext context = await httpListener.GetContextAsync();
    if (context.Request.IsWebSocketRequest)
    {
        webSocketContext = await context.AcceptWebSocketAsync(null);
        WebSocket webSocket = context.WebSocket;
        while (webSocket.State == WebSocketState.Open)
        {
            await webSocket.SendAsync( ... );
        }
    }
