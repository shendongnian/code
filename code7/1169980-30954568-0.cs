    private static TreeNode CreateDirectoryNode(DirectoryInfo directoryInfo)
            {
                var directoryNode = new TreeNode(directoryInfo.Name);
    
                try
                {
                    int flag = 0;
    
                    foreach (var file in directoryInfo.GetFiles())
                    {
                        if (file.Name.EndsWith("txt"))
                        {
                            flag = 1;
                            
                        }
                    }
                    if (flag == 0)
                    {
                        foreach (var directory in directoryInfo.GetDirectories())
                        {
    
                            directoryNode.Nodes.Add(CreateDirectoryNode(directory));
                        }
                    }
    
                    return directoryNode;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return null;
                }
            }
