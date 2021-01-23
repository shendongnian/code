    public class NewsViewModel
    {
         public NewsViewModel(SettingsModel settings)
         {
             //do whatever you need with the setting
             var timer = new DispatcherTimer();
             timer.Interval = settings.DownloadInterval;
             //alternativly you can use something like SettingsModel.Current to access the instance
            // or AppContext.Current.Settings
            // or ServiceLocator.GetService<SettingsModel>()
         }
    }
    public class SettingsViewModel
    {
         public SettingsViewModel(SettingsModel settings)
         {
            Model = settings;
         }
         public SettingsModel Model{get; private set;}
    }
