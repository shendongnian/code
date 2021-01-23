            public Window1()
        {
            InitializeComponent();
            ((INotifyCollectionChanged)mylistbox.Items).CollectionChanged += myListBox_CollectionChanged;
        }
            private void myListBox_CollectionChanged(object sender,NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                foreach (var item in e.NewItems)
                {
                    
                }
            }
        }
