    private string[] filename;
    private async void Button_Click(object sender, RoutedEventArgs e)
    {
        FolderPicker picker = new FolderPicker();
        picker.SuggestedStartLocation = PickerLocationId.ComputerFolder;
        picker.FileTypeFilter.Add("*"); //match all the file format
    
        StorageFolder folder = await picker.PickSingleFolderAsync();
    
        if (folder != null)
        {
            var subFiles = await folder.GetFilesAsync();
            filename = new string[subFiles.Count()];
            for (int i = 0; i < subFiles.Count(); i++)
            {
                filename[i] = subFiles.ElementAt(i).DisplayName;
                textBlock.Text = textBlock.Text + "+" + filename[i]; //show the file name in a textblock
            }
        }
    }
