    using (WebClient wc = new WebClient())
    {
        var url = currentURL+ "home/scanserver";
        wc.Headers.Add("Authorization", token);
        var json = wc.UploadStringTaskAsync(url, "FQDN=allscan").Result;
    }
