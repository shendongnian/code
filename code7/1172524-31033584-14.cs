        public  ObservableCollection<DupInfo> items
        {
            get { return ( ObservableCollection<DupInfo>)GetValue(itemsProperty); }
            set { SetValue(itemsProperty, value); }
        }
        // Using a DependencyProperty as the backing store for items.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty itemsProperty =
            DependencyProperty.Register("items", typeof( ObservableCollection<DupInfo>), typeof(MainWindow), new PropertyMetadata(null));
