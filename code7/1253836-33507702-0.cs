    private void PrintRecursive(TreeNode treeNode)
    {
      // Print the node.
      System.Diagnostics.Debug.WriteLine(treeNode.Text);
      MessageBox.Show(treeNode.Text);
      // Print each node recursively.
      foreach (TreeNode tn in treeNode.Nodes)
      {
        PrintRecursive(tn);
      }
    }
    // Call the procedure using the TreeView.
    private void CallRecursive(TreeView treeView)
    {
       // Print each node recursively.
       TreeNodeCollection nodes = treeView.Nodes;
       foreach (TreeNode n in nodes)
       {
        PrintRecursive(n);
       }
     }
