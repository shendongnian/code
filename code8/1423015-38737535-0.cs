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
                    //Add the image url to globally stored Images1a<String> list
                    Images1a.Add(image);
                }
                    Banner file1 = new Banner();
                    file1.Image = image;
                    file1.URL = url;
                    playlistTimer1a = new DispatcherTimer();
                    playlistTimer1a.Interval = new TimeSpan(0, 0, 6);
                    playlistTimer1a.Tick += playlistTimer_Tick1a;
                    topBanner.Source = new BitmapImage(new Uri(file1.Image));
                    playlistTimer1a.Start();
            }
            catch (HttpRequestException ex)
            {
                RequestException();
            }
        }
