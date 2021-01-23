    public class WeatherThisWeekViewModel : PropertyChangedBase
    {
        private bool initialized;
        public bool Initialized
        {
            get
            {
                return initialized;
            }
            set
            {
                if (initialized != value)
                {
                    initialized = value;
                    OnPropertyChanged();
                }
            }
        }
