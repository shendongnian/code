    public class ViewModel
    {
        public ObservableCollection<ImageSource> Images { get; private set; }
            = new ObservableCollection<ImageSource>();
        public async Task DownloadImages()
        {
            var httpClient = new HttpClient();
            for (int y = 0; y < 16; y++)
            {
                for (int x = 0; x < 16; x++)
                {
                    var url = string.Format(
                        "http://tile.openstreetmap.org/4/{0}/{1}.png", x, y);
                    // the await here makes the download asynchronous
                    var buffer = await httpClient.GetByteArrayAsync(url);
                    using (var stream = new MemoryStream(buffer))
                    {
                        Images.Add(BitmapFrame.Create(
                            stream, BitmapCreateOptions.None, BitmapCacheOption.OnLoad));
                    }
                }
            }
        }
    }
 
