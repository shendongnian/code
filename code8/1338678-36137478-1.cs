    private void GetFiles(DirectoryInfo directory, TreeNode tree) 
    { 
        Application.Current.Dispatcher.BeginInvoke(new Action(() =>
        {
            for (int i = 0; i < allFiles.GetLength(0); i++) 
            { 
                tree.Nodes.Add(allFiles[i].Name);
            }
        }));
    }
