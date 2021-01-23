    public MyUserControl() {
        InitializeComponent();
        DataView = FindResource( "DataView" ) as CollectionViewSource;
        DataView.Source = YourObservableCollection;
    }
