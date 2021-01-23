    public class MyModel
    {
        public Dictionary<int, string> MySettings { get; set; }
        
        //One way of handling it.
        private Dictionary<Settings, string> MyBetterSettings
        {
            get { return MySettings.ToDictionary(setting => (Settings) setting.Key, setting => setting.Value); }
            set { MySettings = value.ToDictionary(setting => (int) setting.Key, setting => setting.Value); }
        }
        //Simple C# 6 methods
        public Dictionary<Settings, string> GetSettings => MySettings.ToDictionary(setting => (Settings) setting.Key, setting => setting.Value);
        public void SetSettings(Dictionary<Settings, string> settings) => MySettings = settings.ToDictionary(setting => (int)setting.Key, setting => setting.Value);
    }
