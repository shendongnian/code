    // C# 6 for brevity
    class BST
    {
        public int Data { get; }
        public BST Left { get; }
        public BST Right { get; }
        public Tree(int data, BST left, BST right) 
        {
            Data = data;
            Left = left;
            Right = right;
        }
    }
