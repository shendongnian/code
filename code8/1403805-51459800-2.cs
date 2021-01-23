    internal class SongLoaderManager
    {
        internal static Stream OpenData(string fileName)
        {
            return Android.App.Application.Context.Assets.Open(fileName);
        }
    }
