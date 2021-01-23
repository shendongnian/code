    public class BinaryTree<T>
    {
        public T Data;
        public BinaryTree<T> Left, Right;
        public BinaryTree()
        {
            this.Left = null;
            this.Right = null;
        }
    
        public static BinaryTree<T> FindNode(T value, BinaryTree<T> myTree)
        {
            if (myTree == null)
                return null;
            else
            {
                int result = Comparer<T>.Default.Compare(value, myTree.Data);
                if (result == 0)
                    return myTree;
                else if (result > 0)
                    return FindNode(value, myTree.Right);
                else if (result < 0)
                    return FindNode(value, myTree.Left);
            }
            return myTree;
        }
    
        public static void RemoveValue(T value, ref BinaryTree<T> myTree)
        {
            if (myTree == null)
                return;
            BinaryTree<T> treeNodeToRemove = FindNode(value, myTree);
    
            // First case: The node to remove has a single subtree
            if(treeNodeToRemove.Left == null ^ treeNodeToRemove.Right == null)
            {
                // We need to change the Left||Right reference of our parent to us...
            }
            // Second case: Both subtrees are null
            else if (treeNodeToRemove.Left == null && treeNodeToRemove.Right == null)
            {
                // We need to change the reference of our parent to null
            }
            // Third case: Both subtrees are full
            else
            {
                // ...
            }
        }
    }
