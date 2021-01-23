    private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
    {
        TreeNode n1 = e.Node;
        // for testing I search for a corresponding node:
        TreeNode n2 = treeView2.Nodes.Find(n1.Name, true).First();
        // for testing I select the node:
        treeView2.SelectedNode = n2;
        // top left points in the node:
        p1 = n1.Bounds.Location;
        p2 = n2.Bounds.Location;
        // add the offset of the treviews:
        p1.Offset(treeView1.Left, treeView1.Top);
        p2.Offset(treeView2.Left, treeView2.Top);
        // trigger the paint event;
        panel1.Invalidate();
    }
