    private void TreeViewAddNode(TreeView treeView, string path, char pathSeparator)
    {
        string[] split = path.Split(pathSeparator);
        
        for(int i = 0; i < split.Length; i++)
        {
            if(i == 0)
            {
                checkTreeView(treeView, split[0]);
            }
            else
            {
                TreeNode node = treeView1.Nodes.Find(split[i - 1], true)[0];
                checkNodes(node, split[i]);                                        
            }
         }                   
     }
    private void checkTreeView(TreeView treeView, string path)
    {
        bool exists = false;
        foreach(TreeNode node in treeView.Nodes)
        {
            if(node.Text == path)
            {
                exists = true;
            }
        }
        if(!exists)
        {
            TreeNode node = treeView.Nodes.Add(path);
            node.Name = path;
        }
    }
    private void checkNodes(TreeNode parent, string path)
    {
        bool exists = false;
        foreach(TreeNode node in parent.Nodes)
        {
            if(node.Text == path)
            {
                exists = true;
            }                
        }
        if(!exists)
        {
            TreeNode node = parent.Nodes.Add(path);
            node.Name = path;
        }
    }
