	var anonymousObjects = context.Subscriptions
		 .Where(c => c.UserId == currentUser.Id)
		 .Select(s => new
		 {
			 NewNotificationsTotalCount = s.TvShow.News
			 .Where(n => n.CreatedOnDatetime > currentUser.LastTimeViewedSubscriptions)
			 .Count()
		 });
