    [System.Web.Services.WebMethod()]
    public static string SaveLike(string ID)
    {
        //
        ActivityFeed.clsFeed objAF = new ActivityFeed.clsFeed();
        ActivityFeed.clsFeeds objAFS = new ActivityFeed.clsFeeds();
        int i;
        string oLikes = "";
        string oSTR;
        objAF = new ActivityFeed.clsFeed();
        objAF.SubFeedItemID = ID_IN;
        objAF.SubFeedEmployeeID = HttpContext.Current.Session["globalEmpID"].ToString();
        objAF.SubFeedIndicatorID = 1;
        objAF.SubFeedComment = "";
        objAF.SubFeedItemDate = DateTime.Now;
        objAF.SaveActivityFeedLike();
    }
