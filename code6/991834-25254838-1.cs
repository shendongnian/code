        public string AName
        {
            get { return (string)GetValue (ANameProperty); }
            set { SetValue (ANameProperty, value); }
        }
        public static readonly DependencyProperty ANameProperty =
            DependencyProperty.Register ("AName", typeof (string), typeof (Connection), new PropertyMetadata (""));
