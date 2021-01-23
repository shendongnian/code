    private void Button1_Click(object sender, EventArgs e)
    {
         ListDirectory("Your TreeView Name here", "root path")
    }
    private void ListDirectory(TreeView tv, string path)
    {
        tv.Nodes.Clear();
        var rootDirectoryInfo = new DirectoryInfo(path);
        tv.Nodes.Add(CreateDirectoryNode(rootDirectoryInfo));
    }
    
    private static TreeNode CreateDirectoryNode(DirectoryInfo directoryInfo)
    {
        var directoryNode = new TreeNode(directoryInfo.Name);
        foreach (var directory in directoryInfo.GetDirectories())
            directoryNode.Nodes.Add(CreateDirectoryNode(directory));
        foreach (var file in directoryInfo.GetFiles())
            directoryNode.Nodes.Add(new TreeNode(file.Name));
        return directoryNode;
    }
