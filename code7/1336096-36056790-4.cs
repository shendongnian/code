    internal class TreeNode<T> where T : class
    {
        public TreeNode(T payload)
        {
            Children = new List<TreeNode<T>>();
            Payload = payload;
        }
        public List<TreeNode<T>> Children { get; }
        public T Payload { get; }
    }
    public static TreeNode<T> CreateTree<T>(int row, int depth, T[][] columns) where T : class
    {
        var node = new TreeNode<T>(columns[depth][row]);
        var maxDepth = columns.GetLength(0) - 1;
        if (depth == maxDepth)
            return new TreeNode<T>(columns[depth][row]);
        var i = row + 1;
        while (true)
        {
            if (i >= columns[depth].Length || columns[depth][i] != null)
                break;
            if (columns[depth + 1][i] != null)
            {
                var child = CreateTree(i, depth + 1, columns);
                node.Children.Add(child);
            }
            i++;
        }
        return node;
    }
