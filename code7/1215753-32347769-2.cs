    public TreeNode CollectParentNodes(TreeNode selectedNode)
    {
       var childRootNodes = selectedNode.Children.Where((childNode) => childNode.Tag == "Folder";
       
       // Clone root node using a copy constructor
       var newRoot = new TreeNode(selectedNode);
       newRoot.Children.Clear();
    
       foreach (var childNode in childRootNodes)
       { 
          // Clone node using a copy constructor
          var copyOfChild = new TreeNode(childNode);
          copyOfChild.Children.Clear();
          // and add it to the new tree
          newRoot.Children.Add(copyOfChild);
          if (childNode.Children.Any())
          {            
             foreach (var child in childNode.Children)
             {
               copyOfChild.Children.Add(CollectParentNodes(childNode));
             }
          }
           
       }
       return newRoot;
    }
