       public RibbonWindow() {
            InitializeComponent();
            ((INotifyCollectionChanged)QuickAccessToolBar.Items).CollectionChanged += QuickAccessToolBar_ItemsCollectionChanged;
        }
        private void QuickAccessToolBar_ItemsCollectionChanged(object sender, NotifyCollectionChangedEventArgs e) {
            switch (e.Action) {
               //Do stuff or synchronize to observableCollection
            }
        }
