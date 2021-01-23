    public void Add(T val)
    {
        bool found;
        RedBlackNode<T> parent = _rootNode;
        while(!found)
        {
            if(val.CompareTo(parent.Data) < 0)
            {
                found = parent.LeftChild == null;
                newNode = newNode.LeftChild;
            }
            else if(val.CompareTo(newNode.Data) >= 0)
            {
                newNode = newNode.RightChild;
            }
        }
        newNode.Data = val;      //nullReferenceException thrown here  <---
        newNode.IsBlack = false;
        FixColors(newNode);
    }
