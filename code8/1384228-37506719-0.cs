        public static readonly DependencyProperty PulsingProperty =
            DependencyProperty.Register("Pulsing", typeof (bool), typeof (GlassButton), new PropertyMetadata(false, OnPulsingPropertyChanged));
        //keep it clean
        public bool Pulsing
        {
            get
            {
                return (bool) GetValue(PulsingProperty);
            }
            set
            {
                SetValue(PulsingProperty, value);
            }
        }
        //here you get your updates
        private static void OnPulsingPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var glassButton = (GlassButton)d;
            var newPulsingValue = (bool)e.NewValue;
            if (newPulsingValue)
                glassButton.BeginAnimation( BackgroundProperty, glassButton._baPulse );
            else
                glassButton.BeginAnimation( BackgroundProperty, null );
        }
