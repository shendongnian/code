    public abstract class Foo
    {
        protected abstract CustomObject CreateCustomObject();
    }
    public class Bar : Foo
    {
        protected override CustomObject CreateCustomObject()
        {
            return new BarCustomObject();
        }
    } 
