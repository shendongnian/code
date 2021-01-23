    using System;					
    public class Program
    {
    	public static void Main()
    	{
    		var a1 = new ClassA();
    		var a2 = new ClassA();
    		
    		Console.WriteLine(a1.GetHashCode());
    		Console.WriteLine(a1.classB.classA.GetHashCode());
    	}
    }
