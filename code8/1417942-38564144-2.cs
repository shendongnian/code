    public class ConcreteComponent {
        public IAttribute Foo {
          get; set;
        }
      }
    
      public class ConcreteAttribute1 : IAttribute {
        public string Name => "ConAtt 1";
        public int Number => 999;
    
      }
      public class ConcreteAttribute2 : IAttribute {
        public string Name => "ConAtt 2";
        public bool B => true;
    
      }
    
      public interface IAttribute {
        string Name {
          get;
        }
      }
