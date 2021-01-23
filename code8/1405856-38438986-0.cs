    public BitmapImage ImageSource 
        { 
            get { return _imageSource; } 
            set { SetProperty(ref _imageSource, value); } 
        }
...
    public async Task GetPhotoAsync(string twrKod)
        {
            using (var httpClient = new HttpClient())
            {
                using (var request = new HttpRequestMessage(HttpMethod.Get,
                    $"http://192.168.0.5/Service/TerminalService.svc/GetPhoto?Code={code}"))
                {
                    using (var response = await httpClient.SendAsync(request))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            var imageStream = await response.Content.ReadAsStreamAsync();
                            var memStream = new MemoryStream();
                            await imageStream.CopyToAsync(memStream);
                            memStream.Position = 0;
                            var bitmap = new BitmapImage();
                            bitmap.SetSource(memStream.AsRandomAccessStream())
                            ImageSource = bitmap;
                        }
                    }
                }
            }
        }
