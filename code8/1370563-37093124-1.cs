    public AppSettings
    {
        private static YourSettingsClass _settings = new YourSettingsClass();
        public static string UserFirstName
        {
            get { return _settings.UserFirstName; }
            set { _settings.UserFirstName = value; }
        }
        public static string UserLastName
        {
            get { return _settings.UserLastName; }
            set { _settings.UserLastName = value; }
        }
        public static string UserScore
        {
            get { return _settings.UserScore; }
            set { _settings.UserScore = value; }
        }
        public static void SaveSettings()
        {
            // Now, use your "settingsfile.xml" (or whatever you're saving as)
            // to write your settings to from your _settings static field object.
            // I'll let you have a play as to how you want to do this...
        }
        public static void LoadSettings()
        {
            YourSettingsClass tempSettingsClass = new YourSettingsClass();
            // Now, use your "settingsfile.xml" (or whatever you've saved it as)
            // to load in your settings and assign to your tempSettingsClass variable.
            // I'll let you have a play as to how you want to do this...
            // Assign the settings from your loaded object.
            _settings = tempSettingsClass;
        }
    }
