    public class SomeLocalizableClass
    {
        //Explicitly declare the backing field for the property!
        private LocalizableSetting<int> _intSetting = new LocalizableSetting<int>();
        public LocalizableSetting<int> IntSetting
        {
            get { return _intSetting; }
            set
            {
                foreach (var kvp in value)
                    _intSetting[kvp.Key] = kvp.Value;
            }
        }
    }
