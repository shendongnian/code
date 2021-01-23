    public static TreeNode CreateDirectoryNode(DirectoryInfo directoryInfo)
        {
            var directoryNode = new TreeNode(directoryInfo.Name);
            foreach (var directory in directoryInfo.GetDirectories())
            {
                 //try
                {
                    directoryNode.Nodes.Add(CreateDirectoryNode(directory));
                } catch {
                    // cannot access directory
                }
            }
            foreach (var file in directoryInfo.GetFiles())
                {
                    directoryNode.Nodes.Add(new TreeNode(file.Name));
                }
                return directoryNode;
            }
