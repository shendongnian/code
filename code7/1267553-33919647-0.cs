    public interface IControlExtension
    {
        Foo PropertyExtension { get; set; } 
        Blach Bar();
    }
    public abstract class ControlExtension: IControlExtension
    {
         private Control owner;
         private ControlExtension(Control owner)
         {
             Debug.Assert(owner != null);
             this.owner = owner;
         }
         public static IControlExtension GetExtension(Control c)
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
         public abstract Foo PropertyExtension { get; set; }
         public abstract Blah Bar();
     
         private class SimpleControlExtension: ControlExtension
         {
              public override Foo { get { ... } set { ... } }
              public override Blah Bar { .... }
         }
         private class ContainerControlExtension: ControlExtension
         {
              public override Foo { get { ... } set { ... } }
              public override Blah Bar { .... }
         }
    }
