    public string HeroName
        {
            get { return (string)GetValue(HeroNameProperty); }
            set { SetValue(HeroNameProperty, value); }
        }
        // Using a DependencyProperty as the backing store for HeroName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty HeroNameProperty =
            DependencyProperty.Register("HeroName", typeof(string), typeof(HeroInformation), new PropertyMetadata(null));
