    internal abstract class SongLoader //under SongLoader.cs
    {
        internal async virtual Task<IEnumerable<Song>> Load();
        internal async virtual Task<Stream> OpenData();
    }
    internal sealed class SongLoaderImplementer : SongLoader //under SongLoaderImplementer.cs
    {
        internal override async Task<IEnumerable<Song> Load() {}
        internal override async Task<Stream> OpenData() {}
    }
