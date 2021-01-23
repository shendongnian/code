    private async Task RunAsync(CancellationToken cancellationToken)
    {
        await Task.WhenAll(
            Task.Run(() =>
            {
                while (!cancellationToken.IsCancellationRequested)
                {
                    Debug.WriteLine("Starting Reddit Service");
                    RedditService.GetObjects();
                    Debug.WriteLine("Completed Reddit Service");
                    await Task.Delay(1000);
                }
            }),
            Task.Run(() =>
            {
                while (!cancellationToken.IsCancellationRequested)
                {
                    Debug.WriteLine("Starting TV Show Service");
                    TVShowTicketService.GetObjects();
                    Debug.WriteLine("Completed TV Show Service");
                    await Task.Delay(1000);
                }
            }),
            Task.Run(() =>
            {
                while (!cancellationToken.IsCancellationRequested)
                {
                    Debug.WriteLine("Starting Play By Play Service");
                    PlayByPlayService.GetObjects();
                    Debug.WriteLine("Completed Play By Play Service");
                    await Task.Delay(1000);
                }
            }),
            Task.Run(() =>
            {
                while (!cancellationToken.IsCancellationRequested)
                {
                    Debug.WriteLine("Starting Profile Service");
                    ProfileService.Main();
                    Debug.WriteLine("Completed Profile Service");
                    await Task.Delay(1000);
                }
            }));
    }
