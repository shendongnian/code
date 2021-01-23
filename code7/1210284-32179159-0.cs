    public class Parent {
      private Child _child;
      public void CreateChild() {
        _child = new Child();
      }
      public void Show() {
        _child.Show();
      }
    }
    
    public class Child : Parent {
    
      public void Show() {
        Console.WriteLine("Working");
      }
    
    }
    
    Parent p = new Parent();
    p.CreateChild();
    p.Show();
