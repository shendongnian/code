        public enum Modes
        {
            Full = 360,
            Half = 180
        }
        public Modes CircularMode
        {
            get { return (Modes)GetValue(CircularModeProperty); }
            set { SetValue(CircularModeProperty, value); }
        }
        public static readonly DependencyProperty CircularModeProperty =
            DependencyProperty.Register("CircularMode", typeof(Modes), typeof(CircularProgressBar), new PropertyMetadata(Modes.Full));
