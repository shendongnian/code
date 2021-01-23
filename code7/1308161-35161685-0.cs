    namespace TreeViewFilesAndFolders
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
                ListDirectory(treeView1, @"C:\Users");
            }
    
            private void ListDirectory(TreeView treeView, string path)
            {
                treeView.Nodes.Clear();
                var rootDirectoryInfo = new DirectoryInfo(path);
                treeView.Nodes.Add(CreateDirectoryNode(rootDirectoryInfo));
            }
    
            private static TreeNode CreateDirectoryNode(DirectoryInfo directoryInfo)
            {
                var directoryNode = new TreeNode(directoryInfo.Name);
    
                var directories = directoryInfo.EnumerateDirectories();
                foreach (var directory in directories)
                {
                    try
                    {
                        directoryNode.Nodes.Add(CreateDirectoryNode(directory));
                    }
                    catch (UnauthorizedAccessException)
                    {
                        Console.WriteLine("Acces denied for directory: " + directory);
                    }
                }
               
                foreach (var file in directoryInfo.GetFiles())
                    directoryNode.Nodes.Add(new TreeNode(file.Name));
                return directoryNode;
            }
        }
    }
