    string userName = HttpUtility.UrlEncode("idontexist");
    string notFoundText = "No player found with this ingame.";
    using (WebClient wc = new WebClient())
    {
        if (wc.DownloadString("https://news.omertabeyond.net/userhistory/" + userName).Contains(notFoundText))
        {
            // doesn't exist
        }
        else
        {
            // does exist
        }
    }
