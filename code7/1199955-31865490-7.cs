    private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
    {
        TreeNode n1 = e.Node;
        TreeNode n2 = treeView2.Nodes.Find(n1.Name, true).First();
        treeView2.SelectedNode = n2;
        p1 = new Point(
              treeView1.Left + n2.Bounds.Left + n1.Bounds.Width + treeView1.BorderWidth,
              treeView1.Top  + n1.Bounds.Top + n1.Bounds.Height / 2 + treeView1.BorderWidth);
        p2 = new Point(
              treeView2.Left + n2.Bounds.Left + treeView2.BorderWidth,
              treeView2.Top  + n2.Bounds.Top + n2.Bounds.Height / 2 + treeView2.BorderWidth);
        float slope = -1f * (p2.Y - p1.Y) / (p2.X - p1.X);
        treeView1.markNode(n1, slope);
        treeView2.markNode(n2, slope);
        panel1.Invalidate();
        treeView1.Invalidate();
        treeView2.Invalidate();
    }
