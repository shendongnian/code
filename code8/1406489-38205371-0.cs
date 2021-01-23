        public Brush XBackground
        {
            get { return (Brush)GetValue(XBackgroundProperty); }
            set { SetValue(XBackgroundProperty, value); }
        }
        // Using a DependencyProperty as the backing store for XBackground.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty XBackgroundProperty =
            DependencyProperty.Register("XBackground", typeof(Brush), typeof(/typeof your UserControl goes here/), new PropertyMetadata(null));
