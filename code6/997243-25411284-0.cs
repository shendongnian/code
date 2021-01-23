    var response = await httpClient.GetAsync(url);
    var result = await response.Content.ReadAsStringAsync();
    
    
    FileSavePicker picker = new FileSavePicker();
    picker.SuggestedFileName = "myjson";
    picker.FileTypeChoices.Add("json file", new List<string> { ".json" });
    picker.SuggestedStartLocation = PickerLocationId.Desktop;
    
    StorageFile file = await picker.PickSaveFileAsync();
    
    await FileIO.WriteTextAsync(file, result);
    
    var status = await CachedFileManager.CompleteUpdatesAsync(file);
    
    if (status == FileUpdateStatus.Complete)
    {
        var md = new MessageDialog("done");
    
        IUICommand x = await md.ShowAsync();
    }
