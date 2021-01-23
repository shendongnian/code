    try
    {
        Uri api = new Uri(string.Format("https://www.googleapis.com/youtube/v3/videos?id={0}&key={1}&part=snippet,statistics", videoIds, AppSettings.Variables.YouTube_APIKey));
        WebRequest request = WebRequest.Create(api);
    
        WebProxy proxy = new WebProxy(AppSettings.Variables.ProxyAddress, AppSettings.Variables.ProxyPort);
        proxy.Credentials = new NetworkCredential(AppSettings.Variables.ProxyUsername, AppSettings.Variables.ProxyPassword, AppSettings.Variables.ProxyDomain);
        request.Proxy = proxy;
    
        using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
        {
            using (StreamReader streamReader = new StreamReader(response.GetResponseStream()))
            {
                return JsonConvert.DeserializeObject<VideoListResponse>(streamReader.ReadToEnd());
            }
        }
    }
    catch (Exception ex)
    {
        ErrorLog.LogError(ex, "Video entity processing error: ");
    }
