        public Visibility AddButtonVisibility
        {
            get { return (Visibility)GetValue(AddButtonVisibilityProperty); }
            set { SetValue(AddButtonVisibilityProperty, value); }
        }
        // Using a DependencyProperty as the backing store for AddButtonVisibility.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AddButtonVisibilityProperty =
            DependencyProperty.Register("AddButtonVisibility", typeof(Visibility), typeof(UserControl1), new PropertyMetadata(Visibility.Visible));
        public Visibility ShowHistoryButtonVisibility
        {
            get { return (Visibility)GetValue(ShowHistoryButtonVisibilityProperty); }
            set { SetValue(ShowHistoryButtonVisibilityProperty, value); }
        }
        // Using a DependencyProperty as the backing store for ShowHistoryButtonVisibility.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ShowHistoryButtonVisibilityProperty =
            DependencyProperty.Register("ShowHistoryButtonVisibility", typeof(Visibility), typeof(UserControl1), new PropertyMetadata(Visibility.Visible));
        public Visibility ShowCustomerButtonVisibility
        {
            get { return (Visibility)GetValue(ShowCustomerButtonVisibilityProperty); }
            set { SetValue(ShowCustomerButtonVisibilityProperty, value); }
        }
        // Using a DependencyProperty as the backing store for ShowCustomerButtonVisibility.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ShowCustomerButtonVisibilityProperty =
            DependencyProperty.Register("ShowCustomerButtonVisibility", typeof(Visibility), typeof(UserControl1), new PropertyMetadata(Visibility.Visible));
