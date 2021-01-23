    public void Add(T val)
    {
          if(_rootNode == null)
          {
               RedBlackNode<T> newNode = new RedBlackNode<T>();
               newNode.Data = val;
               newNode.IsBlack = false;
               _rootNode = newNode;
               return;
          }
          //Followed by your logic
    }
