    class Album {
      private readonly List<Track> _tracklist;
      public ReadOnlyCollection<Track> Tracklist {
        get {
          return new ReadOnlyCollection<Track>(_tracklist);
        }
     }
      public Album(IEnumerable<Track> tracklist) {
        _tracklist = new List<Track>(tracklist);
      }
    }
