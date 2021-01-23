    protected async override void OnBeforeExpand(TreeViewCancelEventArgs e)
    {
        await Task.Run(() =>
        {
            if (!_expandedCache.Contains(e.Node.FullPath))
            {
                ShellFileGetInfo.FolderIcons fi;
                _expandedCache.Add(e.Node.FullPath);
                string curPath;
                List<Tuple<TreeNode,Icon,Icon>> nodesAndIcons = new List<Tuple<TreeNode,Icon,Icon>>();
                foreach (TreeNode n in e.Node.Nodes)
                {
                    curPath = Path.Combine((string)Tag, n.FullPath.Replace('/', Path.DirectorySeparatorChar));
                    if (File.Exists(Path.Combine(curPath, "desktop.ini")) == true)
                    {
                        if (File.ReadAllText(Path.Combine(curPath, "desktop.ini")).Contains("IconFile"))
                        {
                            fi = ShellFileGetInfo.GetFolderIcon(curPath, false);
                            if (fi.closed != null || fi.open != null)
                            {
                                nodesAndIcons.Add(new Tuple<TreeNode,Icon,Icon>(n, fi.closed, fi.open));
                            }
                        }
                    }
                }
                if (InvokeRequired)
                {
                    Invoke((MethodInvoker)(() =>
                    {
                        BeginUpdate();
                        foreach(var tuple in nodesAndIcons)
                        {
                            ImageList.Images.Add(tuple.Value2);
                            ImageList.Images.Add(tuple.Value3);
                            tuple.Value1.SelectedImageIndex = ImageList.Images.Count - 1;
                            tuple.Value1.ImageIndex = ImageList.Images.Count - 2;
                        }
                        EndUpdate();
                    }));
                 }
                 else
                 {
                    BeginUpdate();
                    foreach(var tuple in nodesAndIcons)
                    {
                        ImageList.Images.Add(tuple.Value2);
                        ImageList.Images.Add(tuple.Value3);
                        tuple.Value1.SelectedImageIndex = ImageList.Images.Count - 1;
                        tuple.Value1.ImageIndex = ImageList.Images.Count - 2;
                    }
                    EndUpdate();
                }
            }
        }
    }
