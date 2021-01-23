    public ObservableCollection<Track> TrackCollection = new ObservableCollection<Track>();
    public async Task GetTrackAsyncTask(string link)
    {
        var result = await StaticMethod.GetJsonStringTask(link);
        if(result!=null)
        {
            var getItem = JsonConvert.DeserializeObject<TracksSoundCloud.RootObject>(result);
            foreach ( var item in getItem.tracks)
            {
                TrackCollection.Add(item);
            }
        }
    }
