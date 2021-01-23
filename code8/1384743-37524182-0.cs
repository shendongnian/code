    internal class Foo{
       public virtual void Bar(){..}
       public virtual Task BarAsync(){..}
    }
    public abstract class Bar {
       public abstract override void Bar;
       public abstract override Task BarAsync;
    }
    public sealed class Baz {
       public void Bar() {..}
       public Task BarAsync() {..}
    }
