    async private void Exec()
            {
                // Get the file location.
                string root = Windows.ApplicationModel.Package.Current.InstalledLocation.Path;
                string path = root + @"\Assets\Images";
                StorageFolder appFolder = await StorageFolder.GetFolderFromPathAsync(path);
                int imageNumber = 1;
                int test = imageNumber;
    
                do
                {
                    string imageFileName = imageNumber + ".jpg";
                    Uri uri = new Uri(path + "\\" + imageFileName);
                    image.Source = new BitmapImage(new Uri(uri.ToString()));
                    await Task.Delay(TimeSpan.FromSeconds(1));
                    test = imageNumber + 1;
                    imageNumber++;
                    string testFile = test + ".jpg";
    
                    if (await appFolder.TryGetItemAsync(testFile) != null)
                    {
                        test = 99999;
                    }
                    else
                    {
                        test = 1;
                    }
                }
                while (test == 99999);
    }
