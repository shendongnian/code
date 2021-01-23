    private void FindByText()
    {
        TreeNodeCollection nodes = treeView1.Nodes;
        foreach (TreeNode n in nodes)
        {
            if (n.Text == this.textBox2.Text)
                n.BackColor = Color.Yellow;
            FindRecursive(n);
        }
    }
