    class Closure
    {
         public Action<BinaryTreeNode<T>> act;
         public Action<BinaryTreeNode<T>> InnerTraverse;
    
         public void InnerTraverseFunc(BinaryTreeNode<T> node)
         {
             if (node == null) return;
             this.act(node);
             this.InnerTraverse(node.Left);
             this.InnerTraverse(node.Right);
         }
    }
    
    public void PreorderTraversal(Action<BinaryTreeNode<T>> act)
    {
        var c = new Closure();
        c.act = act;
        c.InnerTraverse = new Action<BinaryTreeNode<T>>(c.InnerTraverseFunc);
        c.InnerTraverse(this.Root);
    }
