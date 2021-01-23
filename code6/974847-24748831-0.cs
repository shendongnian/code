        public interface IA<T,U> {}
        public class X<T> : IA<T,int> {}
        public class Y<T> : IA<T,string> {}
        public interface IB<T,U>
        {
            void MyMethod(IA<T,U> value);
        }
        IB<int,int> foo;
        X<int> a;
        T<int> b;
        foo.MyMethod(a); // will compile
        foo.MyMethod(b); // will not compile
