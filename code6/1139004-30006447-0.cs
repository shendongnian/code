    public void BuildTree(DirectoryInfo directoryInfo, TreeNodeCollection addInMe)
    {
        TreeNode curNode = addInMe.Add(directoryInfo.Name);
        foreach (FileInfo file in directoryInfo.GetFiles())
        {
            TreeNode musicNode = curNode.Nodes.Add(file.FullName, file.Name);
            musicNode.Tag = file.FullName;
        }
        foreach (DirectoryInfo subdir in directoryInfo.GetDirectories())
        {
            BuildTree(subdir, curNode.Nodes);
        }
    }
