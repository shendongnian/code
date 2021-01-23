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
          // Iterate over all children and add them to the new tree
          if (childNode.Children.Any())
          {       
             // Repeat steps for the children of the current child                        
             newRoot.Children.Add(CollectFolderChildNodes(childNode));             
          }     
          else
            newRoot.Children.Add(new TreeNode(childNode));      
       }
       
       return newRoot;
    }
