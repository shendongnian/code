    [HubMethodName("listenToEvents")]
    public async Task ListenToEvents(string visitorId)
    {
        this.NotifyVisitorListeners();
    }
