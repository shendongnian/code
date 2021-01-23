            private async Task<BitmapImage> GetImage(string path)
            {
                using (var webCLient = new Windows.Web.Http.HttpClient())
                {
                    webCLient.DefaultRequestHeaders.Add("User-Agent", "bot");
                    var responseStream = await webCLient.GetBufferAsync(new Uri(path));
                    var memoryStream = new MemoryStream(responseStream.ToArray());
                    memoryStream.Position = 0;
                    var bitmap = new BitmapImage();
                    await bitmap.SetSourceAsync(memoryStream.AsRandomAccessStream());
                    return bitmap;
                }
            }
