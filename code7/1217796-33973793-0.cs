    // Lock object for synchronization;
    private readonly object _syncLock = new object();
    public MainWindow()
    {
	    InitializeComponent();
    
        // Sync collection with UI
        BindingOperations.CollectionRegistering += BindingOperations_CollectionRegistering;
    }
    private void BindingOperations_CollectionRegistering(object sender, CollectionRegisteringEventArgs e)
    {
        // Ensure collection exists
        if (Customers == null || Customers.customerslist == null) return;
        // Ensure collection is synched with UI
        var myCollection = Customers.customerslist;
        if (!Equals(e.Collection, myCollection)) return;
        BindingOperations.EnableCollectionSynchronization(myCollection, _syncLock);
    }
