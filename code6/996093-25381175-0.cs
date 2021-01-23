    class YourType
    {
       public List<YourType> Childs;
       public string Name;
    }
    
    void recursiveMethod(List<YourType> parents)
    {
      foreach(YourType parent in parents)
      {
        Node parentNode = new Node(parent.Name);
        treeView.Nodes.Add(parentNode);
        if(parent.Childs.Count > 0) //we have child nodes
          recursiveMethod(parent.Childs); //recursion
      }
    }
