    protected async override void OnBeforeExpand(TreeViewCancelEventArgs e)
    {
        if (!_expandedCache.Contains(e.Node.FullPath))
        {
            TreeNodeCollection tnc = e.Node.Nodes;
            _expandedCache.Add(e.Node.FullPath);
            await Task.Run(() => { 
                Dictionary<string, ShellFileGetInfo.FolderIcons> icons = new Dictionary<string, ShellFileGetInfo.FolderIcons>();
                ShellFileGetInfo.FolderIcons fi;
                string curPath;
                foreach (TreeNode n in tnc)
                {
                    curPath = Path.Combine((string)Tag, n.FullPath.Replace('/', Path.DirectorySeparatorChar));
                    if (File.Exists(Path.Combine(curPath, "desktop.ini")) == true)
                    {
                        if (File.ReadAllText(Path.Combine(curPath, "desktop.ini")).Contains("IconResource"))
                        {
                            fi = ShellFileGetInfo.GetFolderIcon(curPath, false);
                            if (fi.closed != null || fi.open != null)
                            {
                                _images.Add(((NtfsUsnJournal.UsnEntry)n.Tag).FileReferenceNumber.ToString(), fi.closed.ToBitmap());
                            }
                        }
                    }
                }
            });
        }
        base.OnBeforeExpand(e);
    }
