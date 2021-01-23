    private static Action EmptyDelegate = delegate() { };
    private void CreateMyTree(List<string> RootNodes,  TreeViewItem ParentNode)
        {
            if(mycheck here....)
             {
                for (int i = 1; i <= RootNodes.Count; i++)
                {
                   TreeViewItem NewTreeItem = new TreeViewItem() { Header = RootNodes[i], IsExpanded = false };
                   ParentNode.Items.Add(NewTreeItem);  
                   updateTreeView();
                } 
             }
            else
            {            
               ///here some checks again and recursion again
               CreateMyTree(RootNodes, ParentNode)
    
            }
    }
    
    private void button1_Click(object sender, RoutedEventArgs e)
    {
         //Create RootNode in TreeView
         TreeViewItem ParentNode = new TreeViewItem() { Header = "TopNode", IsExpanded = true };
          //update TreeView GUI
         treeView1.Items.Add(ParentNode);
         //Recursively add items to TreeView
         CreateMyTree(RootNode, ParentNode);
    
   
    
    }
    
    private void updateTreeView()
    {
      treeView1.Dispatcher.Invoke(DispatcherPriority.Background, EmptyDelegate);
    }
