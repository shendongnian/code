    public MainWindow()
    {
        InitializeComponent();
        var rootNode1 = new TreeViewItem() { Header = "Italy" };
        var rootNode2 = new TreeViewItem() { Header = "Germany" };
        nation_team.Items.Add(rootNode1);
        nation_team.Items.Add(rootNode2);
    }
    
    private void nation_team_SelectionChanged(object sender, RoutedPropertyChangedEventArgs<Object> e)
    {
        TreeViewItem rootNode = (TreeViewItem)e.NewValue;
        for (int i = 0; i < 3; ++i)
        {
            rootNode.Items.Add(new TreeViewItem() { Header = "some data" });
        }
    }
