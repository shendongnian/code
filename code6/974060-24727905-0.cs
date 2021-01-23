        private string savedImagePath = string.Empty;
        private void SomeButton_Click(object sender, RoutedEventArgs e)
        {
            WebClient client = new WebClient();
            client.OpenReadCompleted += async (s, args) =>
            {
                using (IsolatedStorageFile storage = IsolatedStorageFile.GetUserStoreForApplication())
                {
                    using (
                        IsolatedStorageFileStream fileStream = new IsolatedStorageFileStream("savedGifName.gif",
                            FileMode.Create, storage))
                    {
                        await args.Result.CopyToAsync(fileStream);
                        savedImagePath = fileStream.Name;
                    }
                }
            };
            client.OpenReadAsync(new Uri("http://www.example.com/someGIF.gif", UriKind.Absolute));
        }
