    Func<string, string> dnsResolve = name => {
        var addrs = Dns.GetHostEntry(name).AddressList;
        return addrs.First(a => a.AddressFamily == AddressFamily.InterNetwork).ToString();
    };
    engine.Execute(pacUtils);
    engine.Script.dnsResolve = dnsResolve;
    engine.Script.myIpAddress = new Func<string>(() => dnsResolve(Dns.GetHostName()));
    engine.Script.alert = new Action<string>(msg => Console.WriteLine("PAC-alert: " + msg));
