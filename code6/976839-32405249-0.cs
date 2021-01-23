    public async Task Accept40KClients()
    {
        for (int i = 0; i < 40000; i++)
        {
            // Await this here   -------v
            bool willRaiseEvent = await listenSocket.AcceptAsync(acceptEventArg);
            if (!willRaiseEvent)
            {
                ProcessAccept(acceptEventArg);
            }
        }
    }
