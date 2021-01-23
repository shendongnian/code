    public class ThemeAwareFrame : Frame
    {
        private static readonly ThemeProxyClass _themeProxyClass = new ThemeProxyClass();
        public static readonly DependencyProperty AppThemeProperty = DependencyProperty.Register(
            "AppTheme", typeof(ElementTheme), typeof(ThemeAwareFrame), new PropertyMetadata(default(ElementTheme), (d, e) => _themeProxyClass.Theme = (ElementTheme)e.NewValue));
        public ElementTheme AppTheme
        {
            get { return (ElementTheme)GetValue(AppThemeProperty); }
            set { SetValue(AppThemeProperty, value); }
        }
        public ThemeAwareFrame(ElementTheme appTheme)
        {
            var themeBinding = new Binding { Source = _themeProxyClass, Path = new PropertyPath("Theme"), Mode = BindingMode.OneWay };
            SetBinding(RequestedThemeProperty, themeBinding);
            AppTheme = appTheme;
        }
        sealed class ThemeProxyClass : INotifyPropertyChanged
        {
            private ElementTheme _theme;
            public ElementTheme Theme
            {
                get { return _theme; }
                set
                {
                    _theme = value;
                    OnPropertyChanged();
                }
            }
            public event PropertyChangedEventHandler PropertyChanged;
            private void OnPropertyChanged([CallerMemberName] string propertyName = null)
            {
                PropertyChangedEventHandler handler = PropertyChanged;
                if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
