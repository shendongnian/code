    public class Settings : INotifyPropertyChanged
    {
        private static volatile Settings instance;
        private static readonly object SyncRoot = new object();
        private ElementTheme appTheme;
        private Settings()
        {
            this.appTheme = ApplicationData.Current.LocalSettings.Values.ContainsKey("AppTheme")
                                ? (ElementTheme)ApplicationData.Current.LocalSettings.Values["AppTheme"]
                                : ElementTheme.Default;
        }
        public static Settings Instance
        {
            get
            {
                if (instance != null)
                {
                    return instance;
                }
                lock (SyncRoot)
                {
                    if (instance == null)
                    {
                        instance = new Settings();
                    }
                }
                return instance;
            }
        }
        public ElementTheme AppTheme
        {
            get
            {
                return this.appTheme;
            }
            set
            {
                ApplicationData.Current.LocalSettings.Values["AppTheme"] = (int)value;
                this.OnPropertyChanged();
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
