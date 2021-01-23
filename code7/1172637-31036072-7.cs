    static class BSTExtensions
    {
        public static BST Insert(this BST bst, BST n)
        {
            if (bst == null)
                return n;
            if (n.Data < bst.Data)
                return new BST(bst.Data, bst.Left.Insert(n), bst.Right);
            if (n.Data > bst.Data)
                return new BST(bst.Data, bst.Left, bst.Right.Insert(n));
            return bst;
        }
    }
