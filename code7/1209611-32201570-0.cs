        private async void button_Click(object sender, RoutedEventArgs e)
        {
            FolderPicker folderPicker = new FolderPicker();
            folderPicker.SuggestedStartLocation = PickerLocationId.Desktop;
            folderPicker.FileTypeFilter.Add(".mp3");
            StorageFolder folder = await folderPicker.PickSingleFolderAsync();
            if (folder != null)
            {
                //get the file list
                var files = await folder.GetFilesAsync(CommonFileQuery.OrderByName).AsTask().ConfigureAwait(false);
                //For example, I can use the following code to play the first item
                if (files.Count > 0)
                {
                    var stream = await files[0].OpenAsync(FileAccessMode.Read);
                    await Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                    {
                        mediaElement.SetSource(stream, files[0].ContentType);
                        mediaElement.Play();
                    });
                }
            }
        }
