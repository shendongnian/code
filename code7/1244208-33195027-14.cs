    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.IO;
    using System.Linq;
    using System.Runtime.CompilerServices;
    namespace DirectoryTree
    {
        public class DirectoryNode : INode, INotifyPropertyChanged
        {
            private ObservableCollection<INode> children;
            public DirectoryNode(DirectoryInfo directoryInfo)
            {
                this.Directory = directoryInfo;
                this.Children = new ObservableCollection<INode>();
            }
            public DirectoryNode(DirectoryInfo directoryInfo, DirectoryNode parent) : this(directoryInfo)
            {
                this.Parent = parent;
            }
            public event PropertyChangedEventHandler PropertyChanged;
            /// <summary>
            /// Gets the name of the folder associated with this node.
            /// </summary>
            public string Name
            {
                get
                {
                    return this.Directory == null ? string.Empty : this.Directory.Name;
                }
            }
            /// <summary>
            /// Gets the path to the directory associated with this node.
            /// </summary>
            public string Path
            {
                get
                {
                    return this.Directory == null ? string.Empty : this.Directory.FullName;
                }
            }
            /// <summary>
            /// Gets the parent directory for this node.
            /// </summary>
            public DirectoryNode Parent { get; private set; }
            /// <summary>
            /// Gets the directory that this node represents.
            /// </summary>
            public DirectoryInfo Directory { get; private set; }
            /// <summary>
            /// Gets or sets the children nodes that this directory node can have.
            /// </summary>
            public ObservableCollection<INode> Children
            {
                get
                {
                    return this.children;
                }
                set
                {
                    this.children = value;
                    this.OnPropertyChanged();
                }
            }
            /// <summary>
            /// Scans the current directory and creates a new collection of children nodes.
            /// The Children nodes collection can be filled with EmptyFolderNode, FileNode or DirectoryNode instances.
            /// The Children collection will always have at least 1 element within it.
            /// </summary>
            public void BuildChildrenNodes()
            {
                // Get all of the folders and files in our current directory.
                FileInfo[] filesInDirectory = this.Directory.GetFiles();
                DirectoryInfo[] directoriesWithinDirectory = this.Directory.GetDirectories();
                // Convert the folders and files into Directory and File nodes and add them to a temporary collection.
                var childrenNodes = new List<INode>();
                childrenNodes.AddRange(directoriesWithinDirectory.Select(dir => new DirectoryNode(dir, this)));
                childrenNodes.AddRange(filesInDirectory.Select(file => new FileNode(this, file)));
            
                if (childrenNodes.Count == 0)
                {
                    // If there are no children directories or files, we setup the Children collection to hold
                    // a single node that represents an empty directory.
                    this.Children = new ObservableCollection<INode>(new List<INode> { new EmptyFolderNode(this) });
                }
                else
                {
                    // We fill our Children collection with the folder and file nodes we previously created above.
                    this.Children = new ObservableCollection<INode>(childrenNodes);
                }
            }
            private void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                var handler = this.PropertyChanged;
                if (handler == null)
                {
                    return;
                }
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
