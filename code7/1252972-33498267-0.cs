            async void PDFButtonToggled(bool i_info)
        {
            await dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                DefaultLaunchFile();
            });
        }
        async void DefaultLaunchFile()
        {
            StorageFolder dataFolder = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFolderAsync("Data");
            StorageFolder streamingAssetsFolder = await dataFolder.GetFolderAsync("StreamingAssets");
            // Path to the file in the app package to launch
            string filePath = "PDFTest.pdf";
            var file = await streamingAssetsFolder.GetFileAsync(filePath);
            if (file != null)
            {
                // Launch the retrieved file
                bool success = await Windows.System.Launcher.LaunchFileAsync(file);
                if (success)
                {
                    // File launched
                }
                else
                {
                    throw new Exception("File launch failed");
                }
            }
            else
            {
                throw new Exception("File not found");
            }
        }
