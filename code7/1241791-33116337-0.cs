    using Knapcode.TorSharp.Tools.Tor;
    TorControlClient tc = new TorControlClient();
    tc.ConnectAsync("localhost", 9051);
    tc.AuthenticateAsync(null); // you should password protect your control connection
    tc.SendCommandAsync("SIGNAL NEWNYM");
