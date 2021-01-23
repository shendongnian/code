    public IEnumerable<TrackInfo> Add(DataContext dataContext, IEnumerable<TrackInfo> tracks)
    {
        return tracks.Select(t => Add(dataContext, t));
    }
    public IEnumerable<TrackInfo> Add(DataContext dataContext, IEnumerable<string> files)
    {
        return Add(dataContext, files.Select(f => new TrackInfo(f));
    }
    public TrackInfo Add(DataContext dataContext, TrackInfo track)
    {
        dataContext.TrackInfos.InsertOnSubmit(track);
        Add(track);
        return track;
    }
