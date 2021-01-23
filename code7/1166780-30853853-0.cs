        public bool UseCustomTooltips
        {
            get { return (bool)GetValue(UseCustomTooltipsProperty); }
            set { SetValue(UseCustomTooltipsProperty, value); }
        }
        public static readonly DependencyProperty UseCustomTooltipsProperty =
            DependencyProperty.Register("UseCustomTooltips", 
            typeof(bool),
            typeof(MyControl), 
            new PropertyMetadata(false, new PropertyChangedCallback(MyCallbackMethod)));
