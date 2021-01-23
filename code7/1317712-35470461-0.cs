    namespace Test
    {
        public class Settings : ObservableSettings
        {
            private static Settings settings = new Settings();
            public static Settings Default
            {
                get { return settings; }
            }
            public Settings()
                : base(ApplicationData.Current.LocalSettings)
            {
            }
            [DefaultSettingValue(Value = 115200)]
            public int Bauds
            {
                get { return Get<int>(); }
                set { Set(value); }
            }
            [DefaultSettingValue(Value = "Jose")]
            public string Name
            {
                get { return Get<string>(); }
                set { Set(value); }
            }
        }
    }
