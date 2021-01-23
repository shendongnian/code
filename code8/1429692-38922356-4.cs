    private async Task RunAsync(CancellationToken cancellationToken)
    {
        await Task.WhenAll(
            RunServiceAsync(cancellationToken, RedditService.GetObjects, "Reddit"),
            RunServiceAsync(cancellationToken, TVShowTicketService.GetObjects, "TV Show"),
            RunServiceAsync(cancellationToken, PlayByPlayService.GetObjects, "Play By Play"),
            RunServiceAsync(cancellationToken, ProfileService.Main, "Profile"));
    }
    Task RunServiceAsync(CancellationToken cancellationToken, Action service, string description)
    {
        return Task.Run(() =>
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                Debug.WriteLine("Starting " + description + " Service");
                service();
                Debug.WriteLine("Completed " + description + " Service");
                await Task.Delay(1000);
            }
        });
    }
