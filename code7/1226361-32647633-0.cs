    public Node Copy()
    {
      Node newNode = new Node();
      newNode.Name = this.Name;
      foreach(var child in this.Children)
      {
          newChild = child.Copy();
          newChild.Parent = newNode;
          newNode.Children.Add(newChild);
      }
      return newNode;
    }
