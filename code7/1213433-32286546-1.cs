    var data = new SettingsViewModel()
    {
      ServiceURI = Constants.GetEndPoint(),
      AutoSync = Constants.DEFAULT_AUTO_SYNC,
      AppDataFolder = Path.Combine(ApplicationData.Current.LocalFolder.Path, Constants.ROOT_FOLDER, Constants.DATA_FOLDER),
      MapKey = Constants.BASIC_MAP_KEY,
      Logging = false
    };
 
