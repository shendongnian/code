    namespace DirectoryTree
    {
        public class EmptyFolderNode : INode
        {
            public EmptyFolderNode(DirectoryNode parent)
            {
                this.Parent = parent;
                this.Name = "Empty.";
            }
            public string Name { get; private set; }
            public string Path
            {
                get
                {
                    return this.Parent == null ? string.Empty : this.Parent.Path;
                }
            }
            public DirectoryNode Parent { get; private set; }
        }
    }
