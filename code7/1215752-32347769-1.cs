    public TreeNode CollectParentNodes(TreeNode selectedNode)
    {
       var childRootNodes = selectedNode.Children.Where((childNode) => childNode.Tag == "Folder";
       
       // Clone root node using a copy constructor
       var newRoot = new TreeNode(selectedNode);
    
       foreach (var childNode in childRootNodes)
       { 
          // Clone node using a copy constructor
          var copyOfChild = new TreeNode(childNode);
          // and add it to the new tree
          newRoot.Children.Add(copyOfChild);
          if (childNode.Children.Any())
          {            
             copyOfChild.Children.Add(CollectParentNodes(childNode));
          }
          else
            return newRoot;
       }
