    static async Task RunIdle(CancellationToken token = default(CancellationToken))
    {
        using (ImapClient Client = new ImapClient("imap.gmail.com", 993, "user", "pass", AuthMethod.Login, true))
        {
    
            ...
    
            var interval = TimeSpan.FromHours(1);
            while (!token.IsCancellationRequested)
            {
                await Task.Delay(interval, token);
            }
        }
    }
