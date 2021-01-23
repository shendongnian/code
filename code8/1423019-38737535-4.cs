        private async void ImageSource1a()
        {
            try
            {
                ...
                foreach (JsonValue groupValue1 in jsonData1)
                {
                    JsonObject groupObject1 = groupValue1.GetObject();
                    string image = groupObject1["image"].GetString();
                    string url = groupObject1["url"].GetString();
                    Images1a.Add(image);
                }
                   //I don't know what is Banner object used for but for this piece of codes, a banner object is not necessary.
                    //Banner file1 = new Banner();
                    //file1.Image = image;
                    //file1.URL = url;
                    playlistTimer1a = new DispatcherTimer();
                    playlistTimer1a.Interval = new TimeSpan(0, 0, 6);
                    playlistTimer1a.Tick += playlistTimer_Tick1a;
                    topBanner.Source = new BitmapImage(new Uri(Images1a[0]));//set the current image to the first one
                    playlistTimer1a.Start();
            }
            catch (HttpRequestException ex)
            {
                RequestException();
            }
        }
