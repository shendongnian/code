         public static readonly DependencyProperty onBackVisibilityProperty =
         DependencyProperty.Register("onBackVisibility", typeof(Visibility), typeof(MyToolBar), new PropertyMetadata(Visibility.Visible));
        public Visibility onBackVisibility
        {
            get { return (Visibility)GetValue(onBackVisibilityProperty); }
            set { SetValue(onBackVisibilityProperty, value); }
        }
