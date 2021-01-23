        public static readonly DependencyProperty UserControlProperty = DependencyProperty.Register("UserControl", 
    typeof(object), typeof(CustomUserControl), new PropertyMetadata(null));
    
       public object UserControl
       {
                get { return GetValue(UserControlProperty); }
                set { SetValue(UserControlProperty, value); }
       }
