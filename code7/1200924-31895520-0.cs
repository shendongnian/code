    public static class AvlFactory
    {
         private static AvlTree _avlTree;
         public static AvlTree AvlTree{ get {return _avlTree; }}
         public static void InitializeTree()
         {
             _avlTree = new AvlTree();
         }
    }
