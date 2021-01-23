    private void Traverse(TreeNodeCollection nodes, string findtext)
    {
        foreach (TreeNode node in nodes)
        {
            if (node.Text.ToString().Trim() == findtext)
            {
                node.TreeView.SelectedNode = node.NextNode;
                treeView1.SelectedNode = node;
                node.TreeView.Focus();
                //MessageBox.Show(node.Text + " is selected...");
            }
            Traverse(node.Nodes, findtext);
        }
    }
