    public class PlaylistEntry<T> : IPlaylistEntry<T>
        where T : IMediaFile
    {
        public string Uri { get; set; }
        public string PlaylistInfo { get; set; }
        public T MediaFile { get; set; }
    }
