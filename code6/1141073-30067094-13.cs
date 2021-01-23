    using System;	
    public class Program
    {
    	public static void Main()
    	{
    		var classA = new ClassA();
    		
    		if(classA.Equals(classA.ClassB1.ClassA) &&
    		   classA.Equals(classA.ClassB2.ClassA) &&
    		   classA.ClassB1.ClassA.Equals(classA.ClassB2.ClassA))
    		{
    			Console.WriteLine("They are the same object.");
    		}
    	}
    }
