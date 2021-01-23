    PendingChanges _pendingChangesPage;
    
    public PendingChanges(page blahh)
    {
       InitializeComponent();
       Datagrid.ItemsSource = obvs_collection;
       _pendingChangesPage = new PendingChanges(blah);
    }
    
    private void CheckChanges()
    {
        PendingChangesTb.Text = _pendingChangesPage.GetPendingChanges();
    }
