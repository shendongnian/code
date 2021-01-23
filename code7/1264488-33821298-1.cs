        void fileSystemWatcher1_Created(object sender, FileSystemEventArgs e)
        {
            var tabName = Path.GetFileName(e.FullPath);
            var tab = tabControl1.TabPages[tabName];
        
            // Do not disable selected tab cause you're working with the tab
            // and you're locking it
            if (tab != tabControl1.SelectedTab)
                tab.Enabled = false;
        }
        void fileSystemWatcher1_Deleted(object sender, FileSystemEventArgs e)
        {
            var tabName = Path.GetFileName(e.FullPath);
            var tab = tabControl1.TabPages[tabName];
            tab.Enabled = true;
        }
