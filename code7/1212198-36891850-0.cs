    public static async void  WriteTrace()
    {
      StorageFolder localFolder = ApplicationData.Current.LocalFolder;
      StorageFolder LogFolder = await localFolder.CreateFolderAsync("LogFiles", CreationCollisionOption.OpenIfExists);
     }
