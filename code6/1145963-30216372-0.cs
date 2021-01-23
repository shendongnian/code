    protected class Node
        {
            public KeyValuePair<TKey, TVal> Data;
            public Node Left, Right;
    
            public Node(KeyValuePair<TKey, TVal> data,
                Node left = null, Node right = null)
            {
                Data = data;
                Left = left; Right = right;
            }
            
            public virtual void Add(Node root, KeyValuePair<TKey, TVal> data)
            {
                //Do whatever
            }
        }
