    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    
    namespace Zoltan
    {    
        public class Program
        {
            public static void Main(string[] args)
            {
                var someStringObj = new SomeClass<string>();
                someStringObj.DoSomeStuff("Hello World.");//prints "Hello World. The default handler does some stuff!"
                
                var someIntObj = new SomeClass<int>();
                someIntObj.DoSomeStuff(1);//prints 3
                
                var someCustomDoubleObj = new SomeClass<double>(d => d - 2);
                someCustomDoubleObj.DoSomeStuff(3);//prints 1
                
                Console.Read();
            }
        }
    }
