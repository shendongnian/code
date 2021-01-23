    public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
                CreateTree();
            }
    
            private void CreateTree()
            {
                treeView.Items.Add(GetTreeView("text"));
            }
    
            private TreeViewItem GetTreeView(string text)
            {
                TreeViewItem newTreeViewItem = new TreeViewItem();
    
                // create stack panel
                StackPanel stack = new StackPanel();
                stack.Orientation = Orientation.Horizontal;
    
                // create Image
                Image image = new Image();
                image.Source = new BitmapImage(new Uri(@"/Images/YourImage.png", UriKind.Relative));
    
                // Label
                TextBlock lbl = new TextBlock();
                lbl.Text = text;
                lbl.TextWrapping = TextWrapping.Wrap;
                lbl.Width = 139;
    
                // Add into stack
                stack.Children.Add(image);
                stack.Children.Add(lbl);
    
                // assign stack to header
                newTreeViewItem.Header = stack;
    
                return newTreeViewItem;
            }
        }
    }
