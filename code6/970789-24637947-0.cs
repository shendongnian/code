    InitializeArchiveContents(explorerTreeView1[nodeIndex], "Program/")
......
    private void InitializeArchiveContents(TreeNode node, string currentDirectory)
    {
        foreach (var node in node.Nodes)
        {
            var attr = File.GetAttributes(node.Tag.ToString());
            if ((attr & FileAttributes.Directory) == FileAttributes.Directory)
            {
                var tmpDir = string.Format("{0}/{1}", currentDirectory, Path.GetDirectoryName(node.Text));
                zip.AddDirectoryByName(tmpDir);
                InitializeArchiveContents(node, tmpDir);
            }
            else
            {
                zip.AddFile(node.Tag.ToString(), currentDirectory);
            }
        }
    }
