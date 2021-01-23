    using System;
    using System.Collections.Generic;
    
                                            
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("first");
    
            // works perfectly!!!
            dynamic foo = new { x=(Action)(() => Console.WriteLine("ok")) };
            foo.x();
    
            // fails
            dynamic foo2 = new { x=(object)(Action)(() => Console.WriteLine("ok2")) };
            foo2.x();
    
        }
    }
