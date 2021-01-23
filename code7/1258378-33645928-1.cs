    public ObservableCollection<TracksSoundCloud> TrackCollection = new ObservableCollection<TracksSoundCloud>();
    public async Task GetTrackAsyncTask(string link)
    {
        var result = await StaticMethod.GetJsonStringTask(link);
        if(result!=null)
        {
            var getItem = JsonConvert.DeserializeObject<TracksSoundCloud.RootObject>(result);
            foreach ( var item in getItem.tracks)
            {
                TracksSoundCloud t = ConvertTrackToTracksSoundCloud(item);//<-- Needs to be implemented
                TrackCollection.Add(item);
            }
        }
    }
