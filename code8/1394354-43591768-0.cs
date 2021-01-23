    string username = "<YOUR_USER_NAME>";
    string url = "https://www.instagram.com/"+ username + "/media/";
    HttpWebRequest instaRequest = WebRequest.Create(url) as HttpWebRequest;
    //optional
    HttpWebResponse instaResponse = instaRequest.GetResponse() as HttpWebResponse;
    string rawJson = new StreamReader(instaResponse.GetResponseStream()).ReadToEnd();
    JObject InstagramJsonFeeds = JObject.Parse(rawJson);
    // Loop through JObject and get the details
    foreach (var Property in InstagramJsonFeeds["items"])
    {
        var ImageUrl = Property["images"]["standard_resolution"]["url"].ToString();
        DateTime DTime = new DateTime(1970, 1, 1).AddSeconds(double.Parse(Property["created_time"].ToString()));
        // Etc Etc ......
    }
