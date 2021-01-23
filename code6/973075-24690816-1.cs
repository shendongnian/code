    private void treeView_ItemDrag(object sender, ItemDragEventArgs e)
    {
    	Debug.WriteLine("ItemDrag fired!");
    	DoDragDrop(e.Item, DragDropEffects.Move);
    }
    
    private void treeView_DragEnter(object sender, DragEventArgs e)
    {
    	Debug.WriteLine("TreeView DragEnter fired!");
    	e.Effect = DragDropEffects.Move;
    }
    
    private void treeView_DragDrop(object sender, DragEventArgs e)
    {
    	Debug.WriteLine("TreeView DragDrop fired!");
    	TreeNode NewNode;
    	if (e.Data.GetDataPresent("System.Windows.Forms.TreeNode", false))
    	{
    		Point pt = ((TreeView)sender).PointToClient(new Point(e.X, e.Y));
    		TreeNode DestinationNode = ((TreeView)sender).GetNodeAt(pt);
    		NewNode = (TreeNode)e.Data.GetData("System.Windows.Forms.TreeNode");
    		if (DestinationNode.TreeView != NewNode.TreeView)
    		{
    			DestinationNode.Nodes.Add((TreeNode)NewNode.Clone());
    			DestinationNode.Expand();
    			//Remove Original Node
    			NewNode.Remove();
    		}
    	}
    }
