    public static partial class SongLoader
    {
        const string Filename = "songs.json";
        public static async Task<IEnumerable<Song>> Load()
        {
            using (var reader = new StreamReader(SongLoaderManager.OpenData())) {
                return JsonConvert.DeserializeObject<List<Song>>(await reader.ReadToEndAsync());
            }
        }
        // NOT NEEDED ANYMORE
        //public static Stream OpenData()
        //{
        //    // TODO: add code to open file here.
        //    return null;
        //}
    }
