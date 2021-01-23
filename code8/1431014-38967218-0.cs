    public class Tree<T>
    {
        // The root of the tree
        private TreeNode<T> root;
    
    
        public Tree(T value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value), "Cannot insert null value!");
            }
    
            root = new TreeNode<T>(value, null);
        }
    
    
        public Tree(T value, params Tree<T>[] children)
            : this(value)
        {
            foreach (Tree<T> child in children)
            {
                root.AddChild(child.root);
            }
        }
    
        public TreeNode<T> Root => root;
    
        public TreeNode<T> FindByValue(T value) => Root.FindByValue(value);
    
    }
    
    
    public class TreeNode<T>
    {
        public TreeNode(T value, TreeNode<T> parent)
        {
            this.parent = parent;
            if (value == null)
            {
                throw new ArgumentNullException(nameof(parent), "Cannot insert null value!");
            }
            this.value = value;
            children = new List<TreeNode<T>>();
        }
    
    
        private T value;
        public TreeNode<T> parent;
        private List<TreeNode<T>> children;
    
    
        public T Value
        {
            get { return value; }
            set { this.value = value; }
        }
        public int ChildrenCount => children.Count;
    
        public TreeNode<T> AddChild(TreeNode<T> child)
        {
            children.Add(child);
            return child;
        }
    
        public TreeNode<T> AddChild(T value) => AddChild(new TreeNode<T>(value, this));
    
        public TreeNode<T> FindByValue(T value)
        {
            if (value.Equals(Value))
                return this;
    
            foreach (var child in children)
            {
                var match = child.FindByValue(value);
                if (match != null)
                    return match;
            }
            return null;
        }
    }
