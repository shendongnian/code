    namespace DirectoryTree
    {
        public class EmptyFolderNode : INode
        {
            public EmptyFolderNode(DirectoryNode parent)
            {
                this.Parent = parent;
                this.Name = "Empty.";
            }
            public string Name { get; }
            public string Path => this.Parent?.Path;
            public DirectoryNode Parent { get; }
        }
    }
