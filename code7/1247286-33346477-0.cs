            try
            {
                TreeNode rootNode;
                NodeInfo nInfo;
                string[] paths = Global.GetPaths();
                for (int i = 0; i < paths.Length; i++)
                {
                    string path = paths[i];
                    DirectoryInfo info = new DirectoryInfo(path);
                    if (info.Exists)
                    {
                        rootNode = new TreeNode(info.Name, 3, 3);
                        rootNode.Name = info.Name;
                        nInfo = new NodeInfo(NodeInfo.Types.Root, info.FullName);
                        rootNode.Tag = nInfo;
                        GetDirectories(info, rootNode);
                        treeView1.Nodes.Add(rootNode);
                        treeView1.SelectedNode = rootNode;
                    }
                }
            }
            catch (Exception ex)
            {
                //.....
                Logic.Log.write("ERROR PopulateTreeView -" + ex.Message);
            }
