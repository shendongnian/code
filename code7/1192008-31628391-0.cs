     [OutputCache(Duration=300)]
    public ActionResult Foo()
    {
        WebClient wc = new WebClient();
        var link = new Uri("http://eu.battle.net/wow/en/feed/news");
        var infoFromLinku = wc.DownloadData(link);
        string sContent = string.Empty;
        sContent = System.Text.Encoding.ASCII.GetString(infoFromLinku);
        ViewBag.yourJsonstring  = sContent;
        return PartialView("_YourPartialView");
    }
        and in PartailView
    <div><pre>@ViewBag.yourJsonstring</pre></div>
