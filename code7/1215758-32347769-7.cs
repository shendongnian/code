    public TreeNode CollectFolderChildNodes(TreeNode selectedNode)
    {
       if (selectedNode.Tag == "Calculation")
          return;
       // Get all the children that are tagged as folder
       var childRootNodes = selectedNode.Children.Where((childNode) => childNode.Tag == "Folder";
       
       // Clone root node using a copy constructor
       var newRoot = new TreeNode(selectedNode);    
       newRoot.Children.Clear();
    
       foreach (var childNode in childRootNodes)
       { 
          // Clone child node (of folder) using a copy constructor
          var copyOfChild = new TreeNode(childNode);
          copyOfChild.Children.Clear();
          // and then add it to the new tree
          newRoot.Children.Add(copyOfChild);
          if (childNode.Children.Any())
          {            
             foreach (var child in childNode.Children)
             {
               // Repeat steps for the children of the current child
               copyOfChild.Children.Add(CollectFolderChildNodes(child));
             }
          }           
       }
       
       return newRoot;
    }
