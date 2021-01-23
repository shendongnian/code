    using (WebClient client = new WebClient())
    {
        client.Headers.Add("Cookie", "AUTH_COOKIE_NAME=" + AUTH_COOKIE_VALUE);
        client.Encoding = Encoding.UTF8;
        html = client.DownloadString(url);
        return html;
    }
