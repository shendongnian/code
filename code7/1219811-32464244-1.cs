    private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
    {
        TreeNode tn=e.Node;
        string loc = currentLocation + "\\" + tn.Text+ ".rtf";
        richTextBox1.LoadFile(loc);
    }
