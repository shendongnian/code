     public static readonly DependencyProperty IsButtonEnabledProperty = DependencyProperty.Register(
                "IsButtonEnabled", typeof(bool), typeof(UserControl1), new PropertyMetadata(default(bool)));
    
            public bool IsButtonEnabled
            {
                get { return (bool)GetValue(IsButtonEnabledProperty); }
                set { SetValue(IsButtonEnabledProperty, value); }
            } 
