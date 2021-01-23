    public abstract class Base
    {
         protected Base()
         {
             //....
             mandatoryMethod();
         }
         private void mandatoryMethod() { ... }
         public abstract Foo Frob();
    }
    public class Derived: Base
    {
         public Derived(....)
         {
             //new Base() will have been called when execution reaches this point.
         }
         public override Foo Frob() { ... }
    }
