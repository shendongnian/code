	class TrackList
	{
		private List<Tracks> _tracks;
		public TrackList()
		{
			_tracks = new List<Tracks>();
		}
		public TrackList(List<Tracks> tracks)
		{
			_tracks = new List<Tracks>(tracks);
		}
	}
