    public class Track
    {
      ...
      [ForeignKey("TrackId")]
      public virtual ICollection<PlaylistTrack> PlaylistTracks { get; set; }
    }
    public class Playlist
    {
      ...
      [ForeignKey("PlaylistId")]
      public virtual ICollection<PlaylistTrack> PlaylistTracks { get; set; }
    }
