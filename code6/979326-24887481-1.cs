    public class Node {
      public virtual bool Evaluate(Person p);
    }
    public class AndNode : Node {
      public IList<Node> Children { get; set; }
      public override bool Evaluate(Person p) {
        foreach(var node in Children) {
          if (!node.Evaluate(person))
            return false;
        }
        return true;
      }
    }
    public class AgeNode : Node {
      public int Value { get; set; }
      public override bool Evaluate(Person p) {
        return p.Age == Value;
      }
    }
    ... etc
     
 
