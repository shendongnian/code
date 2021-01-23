    private void GetFiles(DirectoryInfo directory, TreeNode tree) 
    { 
        Dispatcher.CurrentDispatcher.BeginInvoke(new Action(() =>
        {
            for (int i = 0; i < allFiles.GetLength(0); i++) 
            { 
                tree.Nodes.Add(allFiles[i].Name);
            }
        }));
    }
