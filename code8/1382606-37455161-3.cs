    bool ticking = false;
    TreeNode clickedNode = null;
    private void treeView1_BeforeSelect(object sender, TreeViewCancelEventArgs e)
    {
        e.Cancel = ticking;
        clickedNode = e.Node;
    }
    private void timer1_Tick(object sender, EventArgs e)
    {
        ticking = true;
        // do your stuff
        ticking = false;
        // try to select the clicked node
        if (clickedNode != null) 
          { treeView1.SelectedNode = clickedNode; clickedNode = null;}
    }
