    public TrackPoint TrackpointClone()
    {
    	double lat = this.Position.Lat;
    	double lon = this.Position.Lng;
    	Bitmap backImg = new Bitmap(this.backImage);
    	TrackPoint pointCopy = new TrackPoint(new PointLatLng(lat, lon), backImg);
    	pointCopy.elevation = this.elevation;
    	pointCopy.time = this.time;
    	pointCopy.trackIndex = this.trackIndex;
    	pointCopy.status = this.status;
    	pointCopy.lastEdit = this.lastEdit;
    	return pointCopy;
    }
    
    And a similar method in the Track class:
    
    public Track TrackClone()
    {
    	Track trackCopy = new Track();
    	trackCopy.Name = this.Name;
    	trackCopy.Description = this.Description;
    	trackCopy.Index = this.Index;
    	trackCopy.Grade = this.Grade;
    	trackCopy.ForHiking = this.ForHiking;
    	trackCopy.ForBikeRoad = this.ForBikeRoad;
    	trackCopy.ForBikeOffRoad = this.ForBikeOffRoad;
    	trackCopy.ForCar = this.ForCar;
    	trackCopy.Points = new List<TrackPoint>();
    	foreach (TrackPoint tp in this.Points)
    		trackCopy.Points.Add(tp.TrackpointClone());
    	return trackCopy;
    }
