    public class Foo : IFooBar
    {
       public Base Update(Base toUpdate)
       {
         var fooInstance = toUpdate as Foo;
         if(fooInstance == null)
         {
            return null;
         }
         fooInstance.FooProperty = "X";
         return fooInstance ;
       }
    }
