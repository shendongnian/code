    public static readonly DependencyProperty SelectedItemsProperty = DependencyProperty.Register("SelectedItems", typeof(object), typeof(UserControl1),
            new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, OnSelectedItemsChanged));
    
        public object SelectedItems
        {
            get { return (object) GetValue(SelectedItemsProperty); }
            set { SetValue(SelectedItemsProperty, value); }
        }
