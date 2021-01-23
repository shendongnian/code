    using System.IO;
    namespace DirectoryTree
    {
        public class FileNode : INode
        {
            public FileNode(DirectoryNode parent, FileInfo file)
            {
                this.File = file;
                this.Parent = parent;
            }
            /// <summary>
            /// Gets the parent of this node.
            /// </summary>
            public DirectoryNode Parent { get; private set; }
            /// <summary>
            /// Gets the file this node represents.
            /// </summary>
            public FileInfo File { get; private set; }
            /// <summary>
            /// Gets the filename for the file associated with this node.
            /// </summary>
            public string Name
            {
                get
                {
                    return this.File == null ? string.Empty : this.File.Name;
                }
            }
            /// <summary>
            /// Gets the path to the file that this node represents.
            /// </summary>
            public string Path
            {
                get
                {
                    return this.File == null ? string.Empty : this.File.FullName;
                }
            }
        }
    }
