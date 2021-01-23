    private TreeNode CreateDirectoryNode(string root, string p)
            {
                var directoryNode = new TreeNode(name);
                directoryNode.Text = name;
                var directoryListing = GetDirectoryListing(path);
    
                var directories = directoryListing.Where(d => d.IsDirectory);
                var files = directoryListing.Where(d => !d.IsDirectory);
    
                foreach (var dir in directories)
                {
                    directoryNode.Nodes.Add(CreateDirectoryNode(dir.FullPath, dir.Name));
                }
                foreach (var file in files)
                {
                    TreeNode tn = new TreeNode(file.Name);
                    tn.Text = file.Name
                    directoryNode.Nodes.Add(new TreeNode(tn));
                }
                return directoryNode;
            }
