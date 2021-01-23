    class Foo: IFoo {
      public void DoFoo() {
        System.Console.WriteLine('Foo is fooing');
      }
    }
    class Bar: IBar {
      public void DoBar() {
        System.Console.WriteLine('Bar is barring');
      }
    }
    
    class FooBar: IFoo, IBar {
      public void DoFoo() {
        System.Console.WriteLine('FooBar is fooing');
      }
      public void DoBar() {
        System.Console.WriteLine('FooBar is barring');
      }
    }
    
    IFoo {
      void DoFoo() {
    }
    IBar {
      void DoBar() {
    }
