    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.IO;
    using System.Runtime.CompilerServices;
    using System.Windows.Input;
    namespace DirectoryTree
    {
        public class MainWindowViewModel : INotifyPropertyChanged, ICommand
        {
            private IEnumerable<INode> rootNodes;
            private INode selectedNode;
            public MainWindowViewModel()
            {
                // We default the app to the Program Files directory as the root.
                string programFilesPath = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
                // Convert our Program Files path string into a DirectoryInfo, and create our initial DirectoryNode.
                var rootDirectoryInfo = new DirectoryInfo(programFilesPath);
                var rootDirectory = new DirectoryNode(rootDirectoryInfo);
                // Tell our root node to build it's children collection.
                rootDirectory.BuildChildrenNodes();
                this.RootNodes = rootDirectory.Children;
            }
            public event PropertyChangedEventHandler PropertyChanged;
            public event EventHandler CanExecuteChanged;
            public IEnumerable<INode> RootNodes
            {
                get
                {
                    return this.rootNodes;
                }
                set
                {
                    this.rootNodes = value;
                    this.OnPropertyChanged();
                }
            }
            public bool CanExecute(object parameter)
            {
                // Only execute our command if we are given a selected item.
                return parameter != null;
            }
            public void Execute(object parameter)
            {
                // Try to cast to a directory node. If it returns null then we are
                // either a FileNode or an EmptyFolderNode. Neither of which we need to react to.
                DirectoryNode currentDirectory = parameter as DirectoryNode;
                if (currentDirectory == null)
                {
                    return;
                }
                // If the current directory has children, then the view is collapsing it.
                // In this scenario, we clear the children out so we don't progressively
                // consume system resources and never let go.
                if (currentDirectory.Children.Count > 0)
                {
                    currentDirectory.Children.Clear();
                    return;
                }
                // If the current directory does not have children, then we build that collection.
                currentDirectory.BuildChildrenNodes();
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
