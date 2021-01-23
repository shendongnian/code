    public ActionResult GetMyFacebookPageFeeds()
    {
     var NumberofFeeds = 3;
     string PageId = "YOUR_FACEBOOK_PAGE_NAME_HERE";
     string AccessToken = "PLACE_YOUR_ACCESS_TOKEN_HERE";
     FBPostsModel posts;
     string FeedRequestUrl = string.Concat("https://graph.facebook.com/" + PageId + "/posts?limit=", NumberofFeeds, "&access_token=", AccessToken);
     HttpWebRequest feedRequest = (HttpWebRequest)WebRequest.Create(FeedRequestUrl);
     feedRequest.Method = "GET";
     feedRequest.Accept = "application/json";
     feedRequest.ContentType = "application/json; charset=utf-8";
     WebResponse feedResponse = (HttpWebResponse)feedRequest.GetResponse();
     using (feedResponse)
     {
        using (var reader = new StreamReader(feedResponse.GetResponseStream()))
        {
           posts = JsonConvert.DeserializeObject<FBPostsModel>(reader.ReadToEnd()); 
        }
     }
     return View(posts);
    }
