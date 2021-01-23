    private async void tglSwitchSplitDisplayMode_Toggled(object sender, RoutedEventArgs e)
        {
            StorageFolder local = ApplicationData.Current.LocalFolder;
            var dataFolder = await local.CreateFolderAsync("Data Folder", CreationCollisionOption.OpenIfExists);
            var file = await dataFolder.CreateFileAsync("SwitchSplitDisplayMode.txt", CreationCollisionOption.ReplaceExisting);
            if (tglSwitchSplitDisplayMode.IsOn)
            { 
                await FileIO.WriteTextAsync(file,"on");
            }
            else await FileIO.WriteTextAsync(file, "off");
        }
