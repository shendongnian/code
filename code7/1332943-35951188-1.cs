    public interface IA<T, out M> where M : IB<T>
    {
        M Foo(T val);
    }
    public interface IB<T>
    {
        void Bar();
    }
    public interface IA1<T> : IA<T, IB1<T>> {}
    public interface IB1<T> : IB<T>
    {
        void Bar1();
    }
    public interface IA2<T> : IA<T, IB2<T>> {}
    public interface IB2<T> : IB<T>
    {
        void Bar2();
    }
    public void MyFunc()
    {
        IA1<int> myA1 = GetMyA1();
        IB1<int> myB1 = myA1.Foo(2);
        myB1.Bar();
        myB1.Bar1();
        IA2<string> myA2 = GetMyA2();
        IB2<string> myB2 = myA2.Foo("Hello World");
        myB2.Bar();
        myB2.Bar2();
    }
