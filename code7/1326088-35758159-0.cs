    var picker = new FolderPicker();
    picker.SuggestedStartLocation = PickerLocationId.MusicLibrary;
    picker.FileTypeFilter.Add(".mp3");
    var folder = await picker.PickSingleFolderAsync();
    var result = await Task.Run(() => Directory.Exists(Path.Combine(folder.Path, "foobar")));
    if (result)
    {
      Debug.WriteLine("Yes");
    }
    else
    {
      Debug.WriteLine("No");
    }
