	// NASTY NASTY ENTITY FRAMEWORK
	var anonymousObjects = context.Subscriptions
		.Where(c => c.UserId == userId)
		.Select(s => new
		{
			SubscriptionId = s.Id,
			TvShowId = s.TvShowId,
			TvShow = s.TvShow,
			TvShowNews = s.TvShow.News.OrderByDescending(n => n.CreatedOnDatetime),
			UserId = s.UserId,
			User = s.User
		});
	anonymousObjects = anonymousObjects.OrderByDescending(x => x.TvShowNews.Max(n => n.CreatedOnDatetime));
	var subscriptions = new List<Subscription>();
	foreach (var oneAnonymousObject in anonymousObjects)
	{
		var subscription = new Subscription
		{
			Id = oneAnonymousObject.SubscriptionId,
			TvShowId = oneAnonymousObject.TvShowId,
			UserId = oneAnonymousObject.UserId,
			TvShow = new TvShow
			{
				Id = oneAnonymousObject.TvShow.Id,
				Title = oneAnonymousObject.TvShow.Title,
				CreatedOnDatetime = oneAnonymousObject.TvShow.CreatedOnDatetime,
				IsPrivate = oneAnonymousObject.TvShow.IsPrivate,
				TotalSubscriptions = oneAnonymousObject.TvShow.TotalSubscriptions,
				News = oneAnonymousObject.TvShowNews.ToList()
			},
			User = oneAnonymousObject.User
		};
		subscriptions.Add(subscription);
	}
