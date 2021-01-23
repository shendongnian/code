    public abstract Parent
    {
       // common non-generic methods
    }
    public interface IFooable<T>
    {
        KeyValuePair<string, T> Foo();
    }
    public class Child1 : Parent, IFooable<int>
    {
        public virtual KeyValuePair<string, int> Foo()
        {
        }
    }
    public class Child2 : Parent, IFooable<string>, IFooable<bool>
    {
        public KeyValuePair<string, string> Foo()
        {
        }
        public KeyValuePair<string, bool> Foo()
        {
        }
    }
