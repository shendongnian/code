    DateTime now = DateTime.Now;
    var posts = Model.Content.Descendants("BlogPost").Where(n => n.GetPropertyValue<DateTime>("blogDate") < now);
    
    foreach (IPublishedContent post in posts)
    {
    	...
    }
