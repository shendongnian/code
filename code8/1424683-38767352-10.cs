     public class Node
     {
         public List<Node> children = new List<Node>();
    
         public string Name;
         public int? Val;
    
         public Node Parent = null;
    
         public Node(string name, int? val, Node fromParent = null) {
             Name = name;
             Val = val;
             if (fromParent != null)
             {
                 Parent = fromParent;
                 fromParent.children.Add(this);
             }
         }
         
     }
