	public ActionResult LatestNews()
	{
		using (NDTMS2UtilsEntities newsEntities = new NDTMS2UtilsEntities())
		{
			var newsItems = newsEntities.News.OrderByDescending(ni => ni.DateCreated).Take(5); // .ToList() may be needed
			var newsModel = new List<NewsManagerViewModel>();
			for(int n = 0; n < newsItems.Count(); n++)
			{
				string newsUrl = new Uri(Request.Url.Scheme + "://" + Request.Url.Host + ":3153/News/Index/" + n).ToString();
				var newsManagerModel = new NewsManagerViewModel()
				{
					Title = item.Title,
					NewsContent = item.NewsContent, 
					DateCreated = (DateTime) item.DateCreated,
					NewsUrl = newsUrl // add the url
				}
				newsModel.Add(newsManagerModel)
			}
			
			return PartialView(newsModel);
		}
	}
   
