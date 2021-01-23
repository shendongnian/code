	public void DelFeed(FeedView feedview)
	{
		using (var result = new TruckDb())
		{
			var t = new Feed
			{
				Id = feedview.Id
			};
			result.Feed.Attatch(t);
			result.Feed.Remove(t);
			result.SaveChanges();
		}
	}
