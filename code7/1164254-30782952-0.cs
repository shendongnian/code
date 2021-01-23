    public void CreateSaveFile(string fileName, TreeView treeView)
    {
        using (StreamWriter streamWriter = new StreamWriter(fileName))
        {
            // Print each node recursively.
            TreeNodeCollection nodes = treeView.Nodes;
            foreach (TreeNode n in nodes)
            {
                WriteRecursive(streamWriter, n);
            }
            streamWriter.Close(); // Optional since we have "using", but good practice to include.
        }
    }
