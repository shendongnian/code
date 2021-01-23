    static void Main(string[] args)
    {
        var root = createNode();
        var search = new DepthFirstSearch(root);
        var result = search.Search(5);
        var arr = result.getPath();
        Console.Write(String.Join("-",arr));
    }
    public class DepthFirstSearch
    {
        private Stack _searchStack;
        private BinaryTreeNode _root;
        public DepthFirstSearch(BinaryTreeNode rootNode)
        {
            _root = rootNode;
            _searchStack = new Stack();
        }
        public BinaryTreeNode Search(int data)
        {
            BinaryTreeNode _current;
            _searchStack.Push(_root);
            while (_searchStack.Count != 0)
            {
                _current = (BinaryTreeNode)_searchStack.Pop();
                if (_current.Data == data)
                {
                    return _current;
                }
                foreach (BinaryTreeNode b in _current.Children.AsEnumerable().Reverse())
                    _searchStack.Push(b);
            }
            return null;
        }
    }
    public class BinaryTreeNode
    {
        public BinaryTreeNode parent { get; set; }
        public List<BinaryTreeNode> Children { get; set; }
        public int Data { get; set; }
        public List<int> getPath()
        {
            var list = new List<int>(){Data};
            if (parent != null)
            {
                list.AddRange(parent.getPath());
            }
            return list;
        }
    }
