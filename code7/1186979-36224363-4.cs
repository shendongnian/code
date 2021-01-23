    [ComVisible(true)]
    [COMServerAssociation(AssociationType.AllFiles)]
    public class CopyFilesExtension : SharpContextMenu
    {
        protected override bool CanShowMenu()
        {
            return true;
        }
        protected override ContextMenuStrip CreateMenu()
        {
            var menu = new ContextMenuStrip();
            var copyFiles = new ToolStripMenuItem { Text = "Copy Files To Folder..." };
            copyFiles.Click += (sender, args) => CopyFiles();
            menu.Items.Add(copyFiles);
            return menu;
        }
        private void CopyFiles()
        {
            ...
        }
    } 
