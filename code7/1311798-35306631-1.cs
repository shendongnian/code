    private static async Task ChangeBackground()
    {
        if (UserProfilePersonalizationSettings.IsSupported())
        {
            Uri uri = new Uri("https://source.unsplash.com/random/1920x1080");
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(uri);
                    if (response != null && response.StatusCode == HttpStatusCode.Ok)
                    {
                        string filename = "background.jpg";
                        var imageFile = await ApplicationData.Current.LocalFolder.CreateFileAsync(filename, CreationCollisionOption.ReplaceExisting);
                        using (IRandomAccessStream stream = await imageFile.OpenAsync(FileAccessMode.ReadWrite))
                        {
                            await response.Content.WriteToStreamAsync(stream);
                        }
                        StorageFile file = await ApplicationData.Current.LocalFolder.GetFileAsync(filename);
                        UserProfilePersonalizationSettings settings = UserProfilePersonalizationSettings.Current;
                        if (!await settings.TrySetWallpaperImageAsync(file))
                        {
                            Debug.WriteLine("Failed");
                        }
                        else
                        {
                            Debug.WriteLine("Success");
                        }
                    }
                }
                catch
                {
                }
            }
        }
    }
