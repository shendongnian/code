    class Tree
    {
        public class Node
        {
            public object Value { get; set; }
            public List<Node> Children { get; set; }
        }
        public Node Root { get; set; }
        public void AddBranch(Tree tree, int add_num)
        {
            Root.Children.Insert(add_num, tree.Root);
        }
    }
