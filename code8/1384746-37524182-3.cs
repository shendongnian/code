    internal class Foo{
       public virtual void Bar(){..}
       public virtual Task BarAsync(){..}
    }
    public abstract class ImplementIt : Foo {
       public abstract override void Bar();
       public abstract override Task BarAsync();
    }
    public sealed class DoNotImplementIt : Foo {
       public override void Bar() {..}
       public override Task BarAsync() {..}
    }
