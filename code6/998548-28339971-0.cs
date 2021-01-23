    private static void LoopAndCheckPingAsync(List<string> addresses)
    {
        Func<string, IObservable<PingReply>> getPingReply = a =>
            Observable.Using(
                () => new Ping(),
                p => Observable.FromAsync<PingReply>(() => p.SendPingAsync(a)));
    
        var query =
            from n in Observable.Interval(TimeSpan.FromSeconds(5)).StartWith(-1L)
            from ps in
            (
                from a in addresses.ToObservable()
                from pr in getPingReply(a)
                select pr
            ).ToArray()
            select String.Join(
                Environment.NewLine,
                ps.Select(p => String.Format("{0}    {1}    {2}",
                        p.Address,
                        p.Status,
                        p.RoundtripTime)));
    
        query.Subscribe(x => Console.WriteLine(x));
    }
