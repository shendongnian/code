    using SharpShell.Attributes;
    using SharpShell.Interop;
    using SharpShell.SharpContextMenu;
    using System;
    using System.IO;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    namespace SendToFolderRename
    {
        [ComVisible(true)]
        [COMServerAssociation(AssociationType.AllFiles)]
        public class SendToFolderRename : SharpContextMenu
        {
            [DllImport("ole32.dll")]
            private static extern int CreateBindCtx(int reserved, out IntPtr ppbc);
            [DllImport("shell32.dll")]
            private static extern int SHOpenFolderAndSelectItems(IntPtr pidlFolder, uint cidl, IntPtr[] apidl, int dwFlags);
            protected override bool CanShowMenu()
            {
                return true;
            }
            protected override ContextMenuStrip CreateMenu()
            {
                var menu = new ContextMenuStrip();
                var itemCountLines = new ToolStripMenuItem
                {
                    Text = "Copy files to subfolder"
                };
                itemCountLines.Click += CopyFilesToSubfolder;
                menu.Items.Add(itemCountLines);
                return menu;
            }
            private void CopyFilesToSubfolder(object sender, EventArgs e)
            {
                //System.Diagnostics.Debugger.Break();
                string firstSelectedFile = SelectedItemPaths.FirstOrDefault();
                if (string.IsNullOrEmpty(firstSelectedFile))
                    return;
                string currentDirPath = (new FileInfo(firstSelectedFile)).DirectoryName;
                string newDirName = Path.GetRandomFileName();
                string newDirPath = Path.Combine(currentDirPath, newDirName);
                DirectoryInfo newDir = Directory.CreateDirectory(newDirPath);
                foreach (string filePath in SelectedItemPaths)
                {
                    FileInfo fileInfo = new FileInfo(filePath);
                    string newFilePath = Path.Combine(fileInfo.DirectoryName, newDirName, fileInfo.Name);
                    File.Copy(filePath, newFilePath);
                }
                SelectItemInExplorer(IntPtr.Zero, newDirPath, true);
            }
            public static void SelectItemInExplorer(IntPtr hwnd, string itemPath, bool edit)
            {
                if (itemPath == null)
                    throw new ArgumentNullException("itemPath");
                IntPtr folder = PathToAbsolutePIDL(hwnd, Path.GetDirectoryName(itemPath));
                IntPtr file = PathToAbsolutePIDL(hwnd, itemPath);
                try
                {
                    SHOpenFolderAndSelectItems(folder, 1, new[] { file }, edit ? 1 : 0);
                }
                finally
                {
                    Shell32.ILFree(folder);
                    Shell32.ILFree(file);
                }
            }
            private static IntPtr GetShellFolderChildrenRelativePIDL(IntPtr hwnd, IShellFolder parentFolder, string displayName)
            {
                IntPtr bindCtx;
                CreateBindCtx(0, out bindCtx);
                uint pchEaten = 0;
                SFGAO pdwAttributes = 0;
                IntPtr ppidl;
                parentFolder.ParseDisplayName(hwnd, bindCtx, displayName, ref pchEaten, out ppidl, ref pdwAttributes);
                return ppidl;
            }
            private static IntPtr PathToAbsolutePIDL(IntPtr hwnd, string path)
            {
                IShellFolder desktopFolder;
                Shell32.SHGetDesktopFolder(out desktopFolder);
                return GetShellFolderChildrenRelativePIDL(hwnd, desktopFolder, path);
            }
        }
    }
