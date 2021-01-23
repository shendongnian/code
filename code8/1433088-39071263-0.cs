    private async void GetUserProfileImageAsync(String token)
    {
        var photoApi = new Uri(@"https://apis.live.net/v5.0/me/picture?access_token=" + token);
        using (var client = new HttpClient())
        {
            var photoResult = await client.GetAsync(photoApi);
            using (var imageStream = await photoResult.Content.ReadAsStreamAsync())
            {
                BitmapImage image = new BitmapImage();
                using (var randomStream = imageStream.AsRandomAccessStream())
                {
                    await image.SetSourceAsync(randomStream);
                    myProfile.Source = image;
                    myProfile.Width = image.PixelWidth;
                    myProfile.Height = image.PixelHeight;
                }
            }
        }
    }
