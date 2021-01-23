    private void GetFiles(DirectoryInfo directory, TreeNode tree) 
    { 
        if (TreeViewControl.InvokeRequired)
        {
            TreeViewControl.BeginInvoke((MethodInvoker)delegate
            {
                for (int i = 0; i < allFiles.GetLength(0); i++) 
                { 
                    tree.Nodes.Add(allFiles[i].Name);
                }
            });
        }
    }
