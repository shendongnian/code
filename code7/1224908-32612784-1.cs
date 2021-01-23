    private async void NewSessionConnected(WebSocketSession session)
    {
        while (session.IsConnected)
        {
            await Task.Delay(1000 / 50);
            session.Send("Hello");
        }
    }
