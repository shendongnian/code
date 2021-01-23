    namespace ConsoleApplication3
    {
        using B = MyLongTypeNotFunToType;
        using C = A<MyLongTypeNotFunToType>;
        public class A<T>
        {
            public static void foo(T foo)
            {
                
            }
        }
    
        public class MyLongTypeNotFunToType
        {
    
        }
    
        class Program
        {
            static void Main(string[] args)
            {
              var x = new B();
              A<B>.foo(x);
              C.foo(x);
            }
        }
    }
