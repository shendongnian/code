    [System.Web.Services.WebMethod]
    public static string NewsSearch(string title)
    {
        var obj = new NewsSearch();
        using (var db = new DbDataContext())
        {
            var q = db.News.Where(x => x.NewsTitle.Contains(title)).Select(x => new
            {
                x.Article,
                x.NewsTitle,
                x.PublishDate
    
            });            
            JavaScriptSerializer json = new JavaScriptSerializer();
            return json.Serialize(q.ToArray());  
        }
    }
