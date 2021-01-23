    using (WebClient wc = new WebClient())
    {
        var url = currentURL+ "home/scanserver?FQDN=allscan";
        wc.Headers.Add("Authorization", token);
        var json =wc.UploadStringTaskAsync(url, "");
    }
