    foreach (var item in usersLi) 
    {
    	if( !newsContainer.ContainsKey( item.Username))
    	{
    		newsContainer.Add(item.UserName, new List<NewsInfo>());		
    	}
    	
    	var newsInfo = new NewsInfo();
    	
    	newsInfo.NewsTitle = item.Title;
    	newsInfo.NewsId = item.Id;
    
    	newsContainer[item.UserName].Add(newsInfo);
    }
