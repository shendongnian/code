    public static class AppStyle
    {
        public static event PropertyChangedEventHandler StaticPropertyChanged;
        private static void OnStaticPropertyChanged(string propertyName)
        {
            StaticPropertyChanged?.Invoke(null, new PropertyChangedEventArgs(propertyName));
        }
        private static SolidColorBrush property = Brushes.Red; // backing field
        public static SolidColorBrush Property
        {
            get { return property; }
            set
            {
                property = value;
                OnStaticPropertyChanged("Property");
            }
        }
        public static void ChangeTheme()
        {
            Property = Brushes.Blue;
        }
    }
