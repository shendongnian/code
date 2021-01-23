    private List<string> _expandedCache;
    protected override void OnBeforeExpand(TreeViewCancelEventArgs e)
    {
        if (!_expandedCache.Contains(e.Node.FullPath))
        {
            BeginUpdate();
            ShellFileGetInfo.FolderIcons fi;
            _expandedCache.Add(e.Node.FullPath);
            string curPath;
            foreach(TreeNode n in e.Node.Nodes)
            {
                curPath = Path.Combine((string)Tag, n.FullPath.Replace('/', Path.DirectorySeparatorChar));
                if (File.Exists(Path.Combine(curPath, "desktop.ini")) == true)
                {
                    fi = ShellFileGetInfo.GetFolderIcon(curPath, false);
                    if(fi.closed != null || fi.open != null)
                    {
                        ImageList.Images.Add(fi.closed);
                        ImageList.Images.Add(fi.open);
                        n.SelectedImageIndex = ImageList.Images.Count - 1;
                        n.ImageIndex = ImageList.Images.Count - 2;
                    }
                }
            }
            EndUpdate();
        }
        base.OnBeforeExpand(e);
    }
