    using System;
    class A1<T1>
    {
        private T1 x;
        public void Method<T2>()
        {
            Console.Write("A1: ");
            T2 y = default(T2);
            Console.WriteLine(y.GetType().Name);
        }
    }
    class B1 : A1<int>
    {
        public void Method()
        {
            Console.Write("B1: ");
            base.Method<char>();
        }
    }
    class A2<T1,T2>
    { 
        private T1 x;
        public void Method()
        {
            T2 y = default(T2);
            Console.Write("A2: ");
            Console.WriteLine(y.GetType().Name);
        }
    }
    class B2 : A2<int,char>
    {
        public new void Method()
        {
            Console.Write("B2: ");
            base.Method();
        }
    }
    class Test
    {
        static void Main()
        {
            B1 b1 = new B1();
            B2 b2 = new B2();
            b1.Method<char>(); //call to A1.Method<T>
            b1.Method<int>(); //call to A1.Method<T>
            b1.Method();  //call to B1.Method with via base.Method<char>
            b2.Method(); //call to B2.Method
            //In essence, in case 1, the generic Method<T>() is still exposed since B1.Method<T> is different from B1.Method()
            //whereas in case 2, there is Method() is closed to char when A2<int,char> is instantiated in B
            //Also, B.Method() hids A2.Method() where as there is no hiding in A1 and B1
        }
    }
