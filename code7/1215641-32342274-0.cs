    class Parent {
      public Child Child { get; set; }
      public Parent() {
        Child = new Child();
      }
    }
    
    class Child {
      public List<string> Strings { get; set; }
      public Child() {
        Strings = new List<string>();
      }
    }
