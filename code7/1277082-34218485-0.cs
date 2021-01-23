    using System;
    					
    using System.Numerics;
    
    
    public class Program
    {
    	public static void Main()
    	{
    		var a = System.Numerics.BigInteger.ModPow (new System.Numerics.BigInteger(21) ,1,new System.Numerics.BigInteger(-5) ) ;
    		
    		var b = BigInteger.Remainder(new BigInteger(21),new BigInteger(-5));
    		
    		Console.WriteLine(a);
    		Console.WriteLine(b);
    		Console.WriteLine("Hello World");
    		
    	}
    }
