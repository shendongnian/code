    using System;
    using System.Collections.Generic;
    
                                            
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("first");
    
            dynamic foo = new { x=3 };
            foo.x.ToString();
    
            Console.WriteLine("second");
            dynamic someObj = ConstructSomeObj(
                    (Action)(() => Console.WriteLine("ok")));
    
            someObj.x();
    
            Console.WriteLine("last");
    
    
            // shows "wtf"
            // someObj.Execute();  // throws RuntimeBinderException 
    
            Console.ReadKey();
        }
    
        static dynamic ConstructSomeObj(dynamic param) 
        { return  new { x = param }; }
    }
