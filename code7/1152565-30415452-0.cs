    public interface IPlaylistEntry<T>
        where T : IMediaFile
    {
        T MediaFile { get; set; }
    }
    
    public class PlaylistEntry<T> : IPlaylistEntry<T>
        where T : IMediaFile
    {
        public int Id { get; set; }
        public string PlaylistInfo { get; set; } //added for testing purposes
        public T MediaFile { get; set; }
    }
