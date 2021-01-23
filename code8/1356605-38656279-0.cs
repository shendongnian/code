    ApplicationDataContainer roamingSettings = ApplicationData.Current.RoamingSettings;
    StorageFolder roamingFolder = ApplicationData.Current.RoamingFolder;
    //Get from roaming settings
    object userName = roamingSettings.Values["UserName"];
    if (userName != null && !string.IsNullOrWhiteSpace(userName.ToString()))
    {
        ViewModel.UserName = userName.ToString();
    }
    //Set to roaming settings
    roamingSettings.Values["UserName"] = ViewModel.UserName;
    //You can also save the info into a file.
    StorageFile processFile = await roamingFolder.CreateFileAsync(processFileName, CreationCollisionOption.ReplaceExisting);
    await FileIO.WriteTextAsync(processFile, ViewModel.GameProcess.ToString());
    //Get from the file
    try
    {
        StorageFile processFile = await roamingFolder.GetFileAsync(processFileName);
        string process = await FileIO.ReadTextAsync(processFile);
        int gameProcess;
        if (process != null && int.TryParse(process.ToString(), out gameProcess) && gameProcess > 0)
        {
            ViewModel.GameProcess = gameProcess;
        }
    }
    catch { }
