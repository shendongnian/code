    using System;
    using System.Collections.Generic;
    
    					
    public class Program
    {
        public static void Main(string[] args)
        {
    		Console.WriteLine("first");
    		
    		dynamic foo = new { x=3 };
    		foo.x.ToString();
        }
    
        static dynamic ConstructSomeObj(dynamic param) 
    	{ return new { x = param }; }
    }
    // [System.TypeAccessException: Attempt by method 'DynamicClass.CallSite.Target(System.Runtime.CompilerServices.Closure, System.Runtime.CompilerServices.CallSite, System.Object)' to access type '<>f__AnonymousType0`1<System.Int32>' failed.]
