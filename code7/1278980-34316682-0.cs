    internal User SaveGoogleYoutubeLogin(string access_token)
    {
        var accessToken = access_token;
        string watchHistoryList = "";
        using (WebClient webclient = new WebClient())
        {
            webclient.Headers.Add(HttpRequestHeader.Authorization,"Bearer " + accessToken);
            webclient.Headers.Add("X-JavaScript-User-Agent", "Google APIs Explorer");
            var respone2 = webclient.DownloadString("https://www.googleapis.com/youtube/v3/channels?part=contentDetails&mine=true&key={your_api_key}");
            Debug.Print(respone2);
            JObject jResponse = JObject.Parse(respone2);
            watchHistoryList = (string)jResponse["items"][0]["contentDetails"]["relatedPlaylists"]["watchHistory"].ToString();
        }
        using (WebClient webclient2 = new WebClient())
        {
            webclient2.Headers.Add(HttpRequestHeader.Authorization, "Bearer " + accessToken);
            webclient2.Headers.Add("X-JavaScript-User-Agent", "Google APIs Explorer");
            var respone2 = webclient2.DownloadString("https://www.googleapis.com/youtube/v3/playlistItems?part=snippet&playlistId="+ watchHistoryList + "&key={your_api_key}");
            Debug.Print(respone2);
            JObject jResponse = JObject.Parse(respone2);
            foreach (var item in jResponse["items"])
            {
                Debug.Print(item.ToString());
            }
            }
