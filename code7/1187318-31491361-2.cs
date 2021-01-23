     private void MainPage_OnLoaded(object sender, RoutedEventArgs e)
        {
            var query = KnownFolders.CameraRoll.CreateFileQuery();
            query.ContentsChanged += QueryContentsChanged; 
            await query.GetFilesAsync();
        }
        void QueryContentsChanged(Windows.Storage.Search.IStorageQueryResultBase sender, object args)
        {
            // your handler code
        }
