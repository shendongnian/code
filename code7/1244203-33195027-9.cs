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
            public DirectoryNode Parent { get; }
            /// <summary>
            /// Gets the file this node represents.
            /// </summary>
            public FileInfo File { get; }
            /// <summary>
            /// Gets the filename for the file associated with this node.
            /// </summary>
            public string Name => this.File?.Name;
            /// <summary>
            /// Gets the path to the file that this node represents.
            /// </summary>
            public string Path => this.File?.FullName;
        }
    }
