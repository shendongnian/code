    namespace XXXViewer.Views
    {
        public partial class ConnectionsControl : UserControl
        {
            private readonly ObservableCollection<ConnectionInfoVM> _tabItems = new ObservableCollection<ConnectionInfoVM>();
            public ObservableCollection<ConnectionInfoVM> TabItems {get {return _tabItems;}}
            public ConnectionsControl()
            {
                InitializeComponent();
                // bindings
                //TabDynamic.ItemsSource = _tabItems;
                TabDynamic.DataContext = this;
            }
            // assume this gets called
            private void AddTabItem(ConnectionInfoVM ci)
            {
                TabItems.Add(ci);
            }
        }
    }
