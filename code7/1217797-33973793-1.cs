    // Lock object for synchronization;
    private readonly object _syncLock = new object();
    /// <summary>
    /// Initializes a new instance of MainWindow.    
    /// </summary>
    public MainWindow()
    {
	    InitializeComponent();
    
        // Sync collection with UI
        BindingOperations.CollectionRegistering += BindingOperations_CollectionRegistering;
    }
    /// <summary>
    /// Handles the CollectionRegistering event of the BindingOperations control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="CollectionRegisteringEventArgs"/> instance containing the event data.</param>
    private void BindingOperations_CollectionRegistering(object sender, CollectionRegisteringEventArgs e)
    {
        // Ensure collection exists
        if (Customers == null || Customers.customerslist == null) return;
        // Ensure collection is synched with UI
        var myCollection = Customers.customerslist;
        if (!Equals(e.Collection, myCollection)) return;
        BindingOperations.EnableCollectionSynchronization(myCollection, _syncLock);
    }
