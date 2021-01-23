    private void tvLocal_BeforeExpand(object sender, TreeViewCancelEventArgs e)
    {
        bool never_expanded =
            e.Node.Nodes.Count == 1
            && e.Node.Nodes[0].Text == "";
        if(never_expanded)
        {
            TreeNode node = fe.EnumerateDirectory(e.Node);
        }
    }
