    public class NewsSearchResult
    {
    	public string Article;
    	public string NewsTitle;
    	public DateTime PublishDate;
    }
    
    public class NewsSearch
    {
    	public List<NewsSearchResult> Results;
    }
    
    [System.Web.Services.WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public static NewsSearch NewsSearch(string title)
    {
    	var obj = new NewsSearch();
        using (var db = new DbDataContext())
        {
            var q = db.News.Where(x => x.NewsTitle.Contains(title)).Select(x => new NewsSearchResult
            {
                Article = x.Article,
                NewsTitle = x.NewsTitle,
                PublishDate = x.PublishDate,
            });            
            obj.Results = q.ToList();  
        }
    	
    	return obj;
    }
