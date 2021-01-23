    using (var client = new WebClient())
    {
        var proxy = new WebProxy();
    
        proxy.Address = new Uri("http://96.44.147.138:6060");
        proxy.Credentials = new NetworkCredential(proxyUsername.Text, proxyPassword.Text);
        proxy.UseDefaultCredentials = false;
        proxy.BypassProxyOnLocal = false;
    
        Console.WriteLine(client.DownloadString("http://bot.whatismyipaddress.com/"));
    }
