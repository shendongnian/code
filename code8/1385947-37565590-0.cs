    Func<string, string> dnsResolve = name => {
        var e = Dns.GetHostEntry(name);
        return e.AddressList.First(a => a.AddressFamily == AddressFamily.InterNetwork).ToString();
    };
    engine.Execute(pacUtils);
    engine.Script.dnsResolve = new Func<string, string>(name => dnsResolve(name));
    engine.Script.myIpAddress = new Func<string>(() => dnsResolve(Dns.GetHostName()));
    engine.Script.alert = new Action<string>(msg => Console.WriteLine("PAC-alert: " + msg));
