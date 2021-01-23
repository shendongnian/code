    public IEnumerable<TrackInfo> Add<T>(DataContext dataContext, IEnumerable<T> tracks) where T : object
    {
		if(typeof(T) == typeof(string)) 
		{
			return tracks.Select(t => Add(dataContext, new TrackInfo(t)));
		}
		else if(typeof(T) == typeof(TrackInfo)) 
		{
			return tracks.Select(t => Add(dataContext, t as TrackInfo));
		}
		else 
		{
			throw new ArgumentException("The type must be string or TrackInfo");
		}
    }
    public TrackInfo Add(DataContext dataContext, TrackInfo track)
    {
        dataContext.TrackInfos.InsertOnSubmit(track);
        Add(track);
        return track;
    }
	// you may not need this
    public TrackInfo Add(DataContext dataContext, string path)
    {
        return Add(dataContext, new TrackInfo(path));
    }
