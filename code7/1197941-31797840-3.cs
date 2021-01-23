	if (currentUser == null)
	{
		return 0;
	}
	// Here we create all "custom objects with custom properties (NewNotificationsTotalCount)" for each tv show.
	var anonymousObjects = context.Subscriptions
		 .Where(s2 => s2.UserId == currentUser.Id && ((s2.TvShow.IsPrivate == false) || (s2.TvShow.IsPrivate == true && s2.UserId == currentUser.Id)))
		 .Select(s => new
		 {
			 NewNotificationsTotalCount = s.TvShow.News.Where(n => n.CreatedOnDatetime > currentUser.LastTimeViewedSubscriptions).Count()
		 });
	var newNotificationsTotalCount = 0;
	// Now we must go through all the anonymous objects we created before and sum together all new news for all tv shows else we would just get the count of new news for only one tv show (if we used something like anonymousObjects.FirstOrDefault() for example).
	foreach (var oneAnonymousObject in anonymousObjects)
	{
		newNotificationsTotalCount = newNotificationsTotalCount + oneAnonymousObject.NewNotificationsTotalCount;
	}
	return newNotificationsTotalCount;
