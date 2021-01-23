    public class Node
    {
      public Node Parent { get; private set; }
      //additional properties etc...
      public string Name { get; set;}
      public int Value {get; set;}
    
      public Node(Node parent)
      {
        Parent = parent;
      }
    }
