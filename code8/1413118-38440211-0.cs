    [NotifyPropertyChanged]
    public class Consts
    {
        public string test2 { get; set; } = "foobar";
        public string test
        {
            get { return GetValue("test"); }
            set { UpdateSetting(nameof(test), value.ToString(CultureInfo.InvariantCulture)); }
        }
        [SafeForDependencyAnalysis]
        public string GetValue(string s) => ConfigurationManager.AppSettings[nameof(s)];
        private void UpdateSetting(string key, string value)
        {
            var cfg = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            cfg.AppSettings.Settings[key].Value = value;
            cfg.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
            NotifyPropertyChangedServices.SignalPropertyChanged(this, key);
        }
    }
