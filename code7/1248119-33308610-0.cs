    public class Settings
    {
        private Dictionary<string, object> _settingsRepository = new Dictionary<string, object>();
        private LanguageSpecificPropertyFactory _factory;
        public Settings()
        {
            _factory = new LanguageSpecificPropertyFactory(this);
        }
        public LanguageSpecificProperty<bool> IsContentDownloaded
        {
            get
            {
                return _factory.GetLanguageProperty("IsContentDownloaded", false);
            }
        }
        private void Set<T>(string propertyName, string lang, T val)
        {
            string fullPropertyName = string.Format("{0}_{1}", propertyName, lang);
            _settingsRepository[fullPropertyName] = val;
        }
        private T Get<T>(string propertyName, string lang, T defaultValue)
        {
            string fullPropertyName = string.Format("{0}_{1}", propertyName, lang);
            if (!_settingsRepository.ContainsKey(fullPropertyName))
            {
                _settingsRepository[fullPropertyName] = defaultValue;
            }
            return (T)_settingsRepository[fullPropertyName];
        }
        public class LanguageSpecificProperty<T>
        {
            private string _properyName;
            private T _defaultValue;
            private Settings _settings;
            internal LanguageSpecificProperty(Settings settings, string propertyName, T defaultValue)
            {
                _properyName = propertyName;
                _defaultValue = defaultValue;
            }
            public T this[string lang]
            {
                get
                {
                    return _settings.Get<T>(_properyName, lang, _defaultValue);
                }
                set
                {
                    _settings.Set<T>(_properyName, lang, value);
                }
            }
        }
        public class LanguageSpecificPropertyFactory
        {
            private Dictionary<string, object> _properties = new Dictionary<string, object>();
            private Settings _settings;
            public LanguageSpecificPropertyFactory(Settings settings)
            {
                _settings = settings;
            }
            internal LanguageSpecificProperty<T> GetLanguageProperty<T>(string propertyName, T defaultValue)
            {
                if (!_properties.ContainsKey(propertyName))
                {
                    _properties.Add(propertyName, new LanguageSpecificProperty<T>(_settings, propertyName, defaultValue));
                }
                return (LanguageSpecificProperty<T>)_properties[propertyName];
            }
        }
    }
