    public MainWindow()
    {
        InitializeComponent();
    
        DataObject.AddCopyingHandler(flowDocumentViewer, OnCopy);
    }
    
    private void OnCopy(object sender, DataObjectEventArgs e)
    {
        e.CancelCommand();
    
        Clipboard.SetText(flowDocumentViewer.Selection.Text);
    }
