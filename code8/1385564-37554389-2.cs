    var eventMap = new Dictionary<int, EventDto>();
    var artistMap = new Dictionary<int, ArtistDto>();
    foreach (var entry in dataSet)
    {
    	EventDto @event;
    	if (!eventMap.TryGetValue(entry.EventId, out @event))
    	{
    		@event = new EventDto
    		{
    			EventId = entry.EventId, 
    			Name = entry.EventName,
    			Slug = entry.EventSlug,
    			Headliners = new List<ArtistDto>()
    		};
    		eventMap.Add(@event.EventId, @event);
    	}
    	if (entry.ArtistId != null)
    	{
    		ArtistDto artist;
    		if (!artistMap.TryGetValue(entry.ArtistId.Value, out artist))
    		{
    			artist = new ArtistDto
    			{
    				ArtistId = entry.ArtistId.Value,
    				Name = entry.ArtistName,
    				Bio = entry.ArtistBio,
    			};
    			artistMap.Add(artist.ArtistId, artist);
    		}
    		@event.Headliners.Add(artist);
    	}
    }
    var resultSet = eventMap.Values.ToList();
