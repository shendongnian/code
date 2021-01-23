    using System;
    using System.Collections.Generic;
    using System.Linq;
    					
    public class Program
    {
    	public class A {}
    	
    	public class B : A {}
    	
    	public class C {}
    	
    	public static void Main()
    	{
    		IEnumerable<A> result = new object [] { new A(), new B(), new C() }.OfType<A>();
    		
                // Result: 2, because there're two instance of type A!
    		Console.WriteLine(result.Count());
    	}
    }
