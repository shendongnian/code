    HTTPListener httpListener = new HttpListener();
    httpListener.Prefixes.Add("http://localhost/");
    httpListener.Start();
    HTTPListenerContext context = await httpListener.GetContextAsync();
    if (context.Request.IsWebSocketRequest)
    {
        HTTPListenerWebSocketContext webSocketContext = await context.AcceptWebSocketAsync(null);
        WebSocket webSocket = webSocketContext.WebSocket;
        while (webSocket.State == WebSocketState.Open)
        {
            await webSocket.SendAsync( ... );
        }
    }
