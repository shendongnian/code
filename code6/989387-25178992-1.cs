    theTargetNode = null
    Timer aTimer = new Timer();
    private void treeView1_DragOver(object sender, DragEventArgs e)
    {
        TreeNode targetNode;
        TreeNode draggedNode;
        GetDraggedAndTargetNode(e, out targetNode, out draggedNode);
        e.Effect = DragDropEffects.Move;
        if (!targetNode.IsExpanded)
        {
            theTargetNode = targetNode;
            // set a Timer of 2 seconds 
            aTimer.Tick += aTimer_Tick;
            aTimer.Interval = 2000;
            aTimer.Enabled = true;
        }
    }
    private void aTimer_Tick(object source, EventArgs)
    {
        aTimer.Stop();
        aTimer.Tick -= aTimer_Tick;
        if (theTargetNode != null) theTargetNode.Expand();
    }
