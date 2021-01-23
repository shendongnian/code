    WebClient client = new WebClient();
    client.Headers.Add("Content-Type", "application/json");
    client.Headers.Add("Accept-Version", "4");
    client.Headers.Add("User-Agent", "v4.1.0.0");
    string res = client.DownloadString(url);
