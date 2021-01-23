    //..... Added to EditableTextBlock user control
        public bool StartupInEdit
        {
            get { return (bool)GetValue(StartupInEditProperty); }
            set { SetValue(StartupInEditProperty, value); }
        }
        
        public static readonly DependencyProperty StartupInEditProperty = 
            DependencyProperty.Register("StartupInEdit", typeof(bool), typeof(EditableTextBlock ), new PropertyMetadata(false));
        private void EditableTextBlock_OnLoaded(object sender, RoutedEventArgs e)
        {
            IsInEditMode = StartupInEditMode;
        }
