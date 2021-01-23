        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ObservableCollection<string> list = new ObservableCollection<string>();
            list.Add("Hallo");
            list.Add("Welt");
            Task t = Store(list);
        }
        public static async Task Store(ObservableCollection<string> list)
        {
            StorageFile file = await GetStorageFileFromApplicationUriAsync();
            if (file == null)
            {
                file = await GetStorageFileFromFileAsync();
            }
                
            if (file != null)
            {
                await file.DeleteAsync();
                await CreateFileInInstallationLocation(list);
            }      
        }
        private static async Task<StorageFile> GetStorageFileFromFileAsync()
        {
            StorageFile file = null;
            if (file == null)
            {
                try
                {
                    StorageFolder folder = Windows.ApplicationModel.Package.Current.InstalledLocation;
                    file = await folder.GetFileAsync("ListCollection.json");
                }
                catch
                { }
            }
            return file;
        }
        private static async Task<StorageFile> GetStorageFileFromApplicationUriAsync()
        {
            StorageFile file = null;
            try
            {
                Uri path = new Uri("ms-appx:///ListCollection.json");
                file = await StorageFile.GetFileFromApplicationUriAsync(path);
            }
            catch
            { }
            return file;
        }
        private static async Task CreateFileInInstallationLocation(ObservableCollection<string> list)
        {
            var pkg = Windows.ApplicationModel.Package.Current;
            var installedLocationFolder = pkg.InstalledLocation;
            try
            {
                var file = await installedLocationFolder.CreateFileAsync("ListCollection.json", Windows.Storage.CreationCollisionOption.GenerateUniqueName);
                var filePath = file.Path;
                DataContractJsonSerializer serialize = new DataContractJsonSerializer(typeof(ObservableCollection<String>));
                using (Stream stream = await file.OpenStreamForWriteAsync())
                {
                    serialize.WriteObject(stream, list);
                    stream.Flush();
                }
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }
        }
