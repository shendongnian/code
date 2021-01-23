    private object lock_ = new object();
    public MainWindow()
    {
       Products = new ObservableCollection<string>();
       BindingOperations.EnableCollectionSynchronization(Products, lock_);
    }
