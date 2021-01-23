    public sealed class ApplicationSettingsManager
    {
        readonly object app;
        readonly Dictionary<string, object> appSettings;
        public ApplicationSettingsManager(object app)
        {
            this.app = app;
            appSettings = new Dictionary<string, object>();
        }
        public object Application { get { return app; } }
        public void SaveSetting(string settingName)
        {
            var propInfo = app.GetType().GetProperty(settingName);
            if (propInfo == null)
                throw new ArgumentException("Specified name is not a valid storable setting.", "setting");
            var value = propInfo.GetValue(app);
            if (appSettings.ContainsKey(settingName))
            {
                appSettings[settingName] = value;
            }
            else
            {
                appSettings.Add(settingName, value);
            }
        }
        public void SaveAllSettings()
        {
            var properties = app.GetType().GetProperties().Where(p => p.CanWrite &&
                                                                 p.CanRead &&
                                                                 p.SetMethod.IsPublic &&
                                                                 p.GetMethod.IsPublic);
            foreach (var p in properties)
            {
                var value = p.GetValue(app);
                if (appSettings.ContainsKey(p.Name))
                {
                    appSettings[p.Name] = value;
                }
                else
                {
                    appSettings.Add(p.Name, value);
                }
            }
        }
        public void RestoreSetting(string settingName)
        {
            if (!appSettings.ContainsKey(settingName))
                throw new ArgumentException("Specified name does not correspond to a valid stored setting.", "settingName");
            var propInfo = app.GetType().GetProperty(settingName);
            propInfo.SetValue(app, appSettings[settingName]);
        }
        public void RestoreAllSettingas()
        {
            foreach (var p in appSettings)
            {
                RestoreSetting(p.Key);
            }
        }
    }
