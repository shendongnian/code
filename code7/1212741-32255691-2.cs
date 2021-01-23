    public MainWindow()
    {
        InitializeComponent();
    
        InitTreeView();
    }
    private void InitTreeView()
    {
    	TreeViewItem rootNode = new TreeViewItem() { Header = "Italia" };
    
    	rootNode.Items.Add(GetSeriesA());
    	rootNode.Items.Add(GetSeriesB());
    
    	treeView.Items.Add(rootNode);
    }
    
    private TreeViewItem GetSeriesA()
    {
    	TreeViewItem item = new TreeViewItem() {Header = "Series A"};
    	item.Header = "Series A";
    	item.Items.Add(new TreeViewItem(){Header = "Inter"});
    	item.Items.Add(new TreeViewItem(){Header = "Milan"});
    	return item;
    }
    
    private TreeViewItem GetSeriesB()
    {
    	TreeViewItem item = new TreeViewItem() { Header = "Series B" };
    
    	item.Items.Add(new TreeViewItem(){Header = "Avellino"});
    	item.Items.Add(new TreeViewItem(){Header = "Salerno"});
    	return item;
    }
