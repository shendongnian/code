        public interface IB<T>
        {
            void MyMethod<U>(IA<T,U> value);
        }
        IB<int> foo = null;
        X<int> a;
        foo.MyMethod(a); // int type is inferred by compiler
