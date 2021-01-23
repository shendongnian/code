    public interface IBarMethods
    {
        void Bar();
        Task BarAsync();
    }
    public class Foo
    {
        public virtual IBarMethods DeMethods()
        {
            // return class containing default methods.
        }
    }
    public class ImplementIt : Foo
    {
        public override IBarMethods DeMethods()
        {
            // return different methods.
        }    
    }
