    public interface IControlExtension
    {
        Foo MyProperty { get; set; } 
        Blah MyMethod();
    }
    public abstract class ControlExtension: IControlExtension
    {
         private Control owner;
         private ControlExtension(Control owner)
         {
             Debug.Assert(owner != null);
             this.owner = owner;
         }
         public static IControlExtension GetControlExtension(Control c)
         {
              if (c is Button ||
                  c is Label)
              {
                  return new SimpleControlExtension(c);
              }
              if (c is Panel || ...
              {
                  return new ContainerControlExtension(c);
              }  
         }
         public abstract Foo MyProperty { get; set; }
         public abstract Blah MyMethod();
     
         private class SimpleControlExtension: ControlExtension
         {
              public override Foo MyProperty { .... }
              public override Blah MyMethod { .... 
         }
         private class ContainerControlExtension: ControlExtension
         {
              public override Foo MyProperty { .... }
              public override Blah MyMethod { .... }
         }
    }
