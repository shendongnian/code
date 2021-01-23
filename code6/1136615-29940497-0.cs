     public bool FooBool
        {
            get { return (bool)GetValue(FooBoolProperty); }
            set { SetValue(FooBoolProperty, value); }
        }
     
        public static readonly DependencyProperty FooBoolProperty =
            DependencyProperty.Register("FooBool", typeof(bool), typeof(ucMyControl), new PropertyMetadata(false));
