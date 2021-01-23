    using Alias = A<MyLongTypeNameIsNotFunToType>;
    public class Dummy
    {
        public Dummy(MyLongTypeNameIsNotFunToType x)
        {
            Alias.foo(x);
        }
    }
