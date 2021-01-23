    internal class SongLoaderManager
    {
        internal static Stream OpenData(string fileName)
        {
            return System.IO.File.OpenRead(fileName);
        }
    }
