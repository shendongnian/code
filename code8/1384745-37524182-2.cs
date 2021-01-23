    internal class Foo{
       public virtual void BarMethod(){..}
       public virtual Task BarMethodAsync(){..}
    }
    public abstract class Bar : Foo {
       public abstract override void BarMethod;
       public abstract override Task BarMethodAsync;
    }
    public sealed class Baz {
       public void BarMethod() {..}
       public Task BarMethodAsync() {..}
    }
