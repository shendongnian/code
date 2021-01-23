    public void Add(T val)
    {
        RedBlackNode<T> parent = _rootNode;
        RedBlackNode<T> target = null;
        while(target == null)
        {
            if(val.CompareTo(parent.Data) < 0)
            {
                if (parent.LeftChild == null) 
                    target = parent.LeftChild = new RedBlackNode<T>(parent);
                else
                    parent = parent.LeftChild;
            }
            else if(val.CompareTo(newNode.Data) >= 0)
            {
                if (parent.RightChild == null) 
                    target = parent.RightChild = new RedBlackNode<T>(parent);
                else
                    parent = parent.RightChild;
            }
        }
        target.Data = val;
        target.IsBlack = false;
        FixColors(newNode);
    }
