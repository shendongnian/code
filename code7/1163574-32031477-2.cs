    public class Foo
    {
      public int baz = 0;
      public int daz = 0;
    
      public A()
      {
        baz = 5;
        daz = 10;
      }
    
      public void Bar(int x)
      {
        x / daz;
      }
    }
