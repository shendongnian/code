    internal class MainWindowVM : ObservableObject
    {
        private ObservableCollection<Node> mRootNodes;
        public IEnumerable<Node> RootNodes { get { return mRootNodes; } }
        public MainWindowVM()
        {
            mRootNodes = new ObservableCollection<Node>();
            // Test data for example purposes
            Node root = new Node() { Name = "Root" };
            Node a = new Node(root) { Name = "Node A" };
            root.Children.Add(a);
            Node b = new Node(root) { Name = "Node B" };
            root.Children.Add(b);
            Node c = new Node(b) { Name = "Node C" };
            b.Children.Add(c);
            Node d = new Node(b) { Name = "Node D" };
            b.Children.Add(d);
            Node e = new Node(root) { Name = "Node E" };
            root.Children.Add(e);
            mRootNodes.Add(root);
        }
    }
