    using System;
    using System.Collections.Generic;
    interface ISomePolicy<U> 
    {
        void _doSomething(U u);
    }
    public class MyClass<U> :
         ISomePolicy<double>,
         ISomePolicy<int>
    {
        internal object myEement { get; set; }
        public MyClass(object Element)
        {
            myEement = Element;
        }
        void ISomePolicy<double>._doSomething(double u)
        {
            Console.WriteLine("this is double");
        }
        void ISomePolicy<int>._doSomething(int u)
        {
            Console.WriteLine("this is int");
        }
    }
    static class MyClassExtension
    {
        public static void doSomething<P, U>(this P oTh, U u) where P : ISomePolicy<U>
        {
            oTh._doSomething(u);
        }
    }
    class Program
    {
        static void Main()
        {
            MyClass<double> oClass = new MyClass<double>(3);
            oClass.doSomething(0.5); //This works
            oClass.doSomething(1);   //This works            
            //oClass.doSomething("Will not work");
        }
    }
