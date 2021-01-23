    private async void ApplyUserSettings()
        {
            try
            {
                StorageFolder local = ApplicationData.Current.LocalFolder;
                var dataFolder = await local.GetFolderAsync("Data Folder");
                var file = await dataFolder.GetFileAsync("SwitchSplitDisplayMode.txt");
                String SwitchSplitDisplayMode = await FileIO.ReadTextAsync(file);
                if (SwitchSplitDisplayMode == "on")
                {
                    ShellSplitView.DisplayMode = SplitViewDisplayMode.Overlay;
                    mainpageAppBarGrid.Margin = new Thickness(48, 0, 0, 0);
                }
                else ShellSplitView.DisplayMode = SplitViewDisplayMode.CompactOverlay;
            }
            catch (Exception)
            {
            }
            
        }
