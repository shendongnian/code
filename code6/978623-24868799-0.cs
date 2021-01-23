        public NcButton()
        {
            this.DefaultStyleKey = typeof(NcButton);
        }
        // you can get help for these properties using the propdp code snippet in C# and Visual Basic
        public Symbol Icon
        {
            get { return (Symbol)GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }
        }
        // Using a DependencyProperty as the backing store for ImagePath.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IconProperty =
            DependencyProperty.Register("Icon", typeof(Symbol), typeof(NcButton), new PropertyMetadata(null));
