    public abstract class A<T> where T : A
    {
        public abstract T Create();
    }
    public class B : T<B>
    {
        public override B Create()
        {
            return new B();
        }
    }
