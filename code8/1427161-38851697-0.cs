    public interface IObj<T>
    {
        void Merge(IObj<T> other);
    }
    public interface IObj<T, TImplementor> : IObj<T>
        where TImplementor : class, IObj<T, TImplementor>
    {
        void Merge(TImplementor other);
    }
    public abstract class AObj<T, TImplementor> : IObj<T, TImplementor>
        where TImplementor : class, IObj<T, TImplementor>
    {
        public abstract void Merge(TImplementor other);
        void IObj<T>.Merge(IObj<T> other)
        {
            var casted = other as TImplementor;
            if (casted == null)
                throw new ArgumentException("Incorrect type.");
            Merge(casted);
        }
    }
    public class A<T> : AObj<T, A<T>>
    {
        override public void Merge(A<T> other)
        {
            // do the actual stuff
        }
    }
    public class B<T> : AObj<T, B<T>>
    {
        override public void Merge(B<T> other)
        {
            // do the actual stuff
        }
    }
