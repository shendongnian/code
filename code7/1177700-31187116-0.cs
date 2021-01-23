    using Newtonsoft.Json;
    using (WebClient wc = new WebClient())
    {
        var json = wc.DownloadString(url);
        var t = JsonConvert.DeserializeObject<whateverClass.you.have.made>(json);
    }
