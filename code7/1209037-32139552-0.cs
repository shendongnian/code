    public interface ISettingsProvider<TSettings> where TSettings : ISettings
    {
        TSettings Settings { get; }
    }
    public class FooSettingsProvider : ISettingsProvider<FooSettings>
    {
        public FooSettingsProvider(SettingsProvider settingsProvider)
        {
            this._settingsProvider = settingsProvider;
            this._settings = new Lazy<FooSettings>(this.InitializeSettings);
        }
        private readonly SettingsProvider _settingsProvider;
        private readonly Lazy<FooSettings> _settings;
        public FooSettings Settings
        {
            get
            {
                return this._settings.Value;
            }
        }
        private FooSettings InitializeSettings()
        {
            var providerSettings = this._settingsProvider.GetSettings("fooSettings");
            var fooSettings = new FooSettings(providerSettings[0], providerSettings[1]);
            return fooSettings;
        }
    }
