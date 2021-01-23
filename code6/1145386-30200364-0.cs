    static async Task RunIdle()
    {
        using (ImapClient Client = new ImapClient("imap.gmail.com", 993, "user", "pass", AuthMethod.Login, true))
        {
    
            ...
    
            while (true)
            {
                await Task.Delay(TimeSpan.FromHours(1));
            }
        }
    }
