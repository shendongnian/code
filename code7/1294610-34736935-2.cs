     Task.Run(async () => { await DownloadFileFromWeb(new Uri(@"http://main.get4mobile.net/ringtone/ringtone/ibMjbqEYMHUnso8MErZ_UQ/1452584693/fa1b23bb5e35c8aed96b1a5aba43df3d/stefano_gambarelli_feat_pochill-land_on_mars_v2.mp3"), "mymp3.mp3"); }).Wait();
        public static async Task<Stream> DownloadFile(Uri url)
        {
            var tcs = new TaskCompletionSource<Stream>();
            HttpClient http = new System.Net.Http.HttpClient();
            HttpResponseMessage response = await http.GetAsync(url);
                MemoryStream stream = new MemoryStream();
                ulong length = 0;
                response.Content.TryComputeLength(out length);
                if (length > 0)
                    await response.Content.WriteToStreamAsync(stream.AsOutputStream());
                stream.Position = 0;
                return stream;
        }
        public static async Task<string> DownloadFileFromWeb(Uri uriToDownload, string fileName)
        {
            using (Stream stream = await DownloadFile(uriToDownload))
            {
                StorageFolder local = Windows.Storage.ApplicationData.Current.LocalFolder;
                var file = await local.CreateFileAsync(fileName, CreationCollisionOption.ReplaceExisting);
                stream.Position = 0;
                using (Stream fileStream = await file.OpenStreamForWriteAsync())
                {
                    stream.CopyTo(fileStream);
                }
                return file.Path;
            }
        }
