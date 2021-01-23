        using (WebClient client = new WebClient()) {
            client.Proxy = new WebProxy("31.4.5.26", 8080); // proxy's host,port
            client.Proxy.Credentials = new NetworkCredential("proxyuser", "proxypassword");
            Console.WriteLine(client.DownloadString("http://bot.whatismyipaddress.com/"));
        }
