    using System;
    using System.Runtime.InteropServices;
    
    class Test
    { 
        static void Main(string[] args) 
        {
            Foo(); // Prints 5 test
        }
  
        static void Foo([Optional, DefaultParameterValue(5)] object x,
                        [Optional, DefaultParameterValue("test")] object y)
        {
            Console.WriteLine("{0} {1}", x, y);
        }    
    }
