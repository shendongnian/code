	var anonymousObject = context.Subscriptions
		 .Where(c => c.UserId == currentUser.Id)
		 .Select(s => new
		 {
			 NewNotificationsTotalCount = s.TvShow.News
			 .Where(n => n.CreatedOnDatetime > currentUser.LastTimeViewedSubscriptions)
			 .Count()
		 });
    // Gets the total count of new/unread news for the current user.
    if (anonymousObject != null)
    {
        var newNotificationsTotalCount = anonymousObject
            .FirstOrDefault()
            .NewNotificationsTotalCount;
    }
