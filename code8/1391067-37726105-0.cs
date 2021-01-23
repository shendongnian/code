    using (WebApp.Start<Startup>(url: baseAddress))
    {
        Console.WriteLine("Web server running at: {0}", baseAddress);
        var tasks = new List<Task>();
        foreach (string hub in hubs) {
            tasks.Add(ReceiveMessagesHubAsync(hub, cancel.Token));
        }
        Task.WaitAll(tasks.ToArray());
    }
    Console.WriteLine ("Web server shut dow");
