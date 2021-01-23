    public void ProcessRequest(HttpContext context) {
        if (context.IsWebSocketRequest) {
            context.AcceptWebSocketRequest(HandleWebSocket);
        }
    }
    private Task HandleWebSocket(WebSocketContext wsContext)
    {
        // Do something useful
    }
