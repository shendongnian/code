    string savefolder, selectedfilename;
    private async void changefolder_button_click(object sender, RoutedEventArgs e)
    {
        folderlist_box.Items.Clear();
        IReadOnlyList<StorageFolder> folderlist = await KnownFolders.PicturesLibrary.GetFoldersAsync();
        string folder_read = "";
        foreach (StorageFolder folder in folderlist)
        {
            if (folder.Name != folder_read)
            //Filter duplicate names like "Camera Roll" from libraries on phone and SDCard (if any).
            //Which one is used depends on: Settings -> Storage Sense.
            {
                folder_listbox.Items.Add(folder.Name);
                folder_read = folder.Name;
            }
        }
    }
