    using System;	
    public class Program
    {
    	public static void Main()
    	{
    		var classA = new ClassA();
    				
    		if(classA.Equals(classA.MyClassB1.MyClassA) &&
    		   classA.Equals(classA.MyClassB2.MyClassA) &&
    		   classA.MyClassB1.MyClassA.Equals(classA.MyClassB2.MyClassA))
    		{
    			Console.WriteLine("They are the same object.");
    		}
    	}
    }
