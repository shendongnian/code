    HttpListener httpListener = new HttpListener();
    httpListener.Prefixes.Add("http://localhost/");
    httpListener.Start();
    HttpListenerContext context = await httpListener.GetContextAsync();
    if (context.Request.IsWebSocketRequest)
    {
        HttpListenerWebSocketContext webSocketContext = await context.AcceptWebSocketAsync(null);
        WebSocket webSocket = webSocketContext.WebSocket;
        while (webSocket.State == WebSocketState.Open)
        {
            await webSocket.SendAsync( ... );
        }
    }
