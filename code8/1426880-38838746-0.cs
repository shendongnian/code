    interface IBar
    {
        object Do(object t);
    }
    interface IBar<T, K> : IBar
    {
        K Do(T t);
    }
    public class BarImpl : IBar<Type, AnotherType>
    {
        public AnotherType Do(Type type)
        {
            return new AnotherType(type);
        }
        public object Do(object t)
        {
            return Do((Type) t);
        }
    }
