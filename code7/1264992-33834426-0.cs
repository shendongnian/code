    namespace Library.Foo // assembly 1
    {
      using Library.Foo.Bar; // error here
    
      public class Bar
      {
        public void DoIt()
        {
          new Bell(); // and here
        }
      }
    }
    
    namespace Library.Foo.Bar // assembly 2
    {
        public class Bell
        {
        }
    }
