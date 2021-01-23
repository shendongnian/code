    public MainWindow()
    {
       InitializeComponent();
       ExtendTree();
    }
    
    private void ExtendTree()
    {
    
        ItemCollection ic = treeView.Items;
        string yourNode = "Sequences";
        foreach (var tvi in ic)
        {
           if (yourNode.StartsWith((TreeViewItem)tvi.Tag.ToString()))
           {
              (TreeViewItem)tvi.IsExpanded = true;
              break;
           }
         }
    }
