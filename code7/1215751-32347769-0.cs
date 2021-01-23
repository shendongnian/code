    public TreeNode CollectParentNodes(TreeNode selectedNode)
    {
       var childRootNodes = selectedNode.Children.Where((childNode) => childNode.Tag == "Folder";
       
       // Clone root node using a copy constructor
       var newRoot = new TreeNode(selectedNode);
       foreach (var childRootNode in childRootNodes)
       {
         // Clone node using a copy constructor
         // and add it to the new tree
         newRoot.Children.Add(new TreeNode(childRootNode));
       }
       // Clone the current item using copy constructor and then set
       // new child items
       var copyOfCurrentItem = new TreeNode(selectedNode);
       copyOfCurrentItem.Children.AddRange(collectedNodes);
    
       foreach (var childNode in newRoot.Children)
       {
          if (childNode.Children.Any())
          {
            CollectParentNodes(childNode);
          }
          else
            return;
       }
