    public abstract class Base
    {
        public abstract void Activate();
    }
    public abstract class Base<T> : Base
        where T : Base
    {
        public override void Activate()
        {
            Foo<T>();
        }
    }
    public class A : Base<A>
    {
    }
    public class B : Base<B>
    {
    }
