    using System;	
    public class Program
    {
    	public static void Main()
    	{
    		var classA = new ClassA();
    		
    		// identical hash codes show that 
    		// all the ClassA instances are probably the same
    		Console.WriteLine(classA.GetHashCode());
    		Console.WriteLine(classA.ClassB1.ClassA.GetHashCode());
    		Console.WriteLine(classA.ClassB2.ClassA.GetHashCode());
    		
    		if(classA.Equals(classA.ClassB1.ClassA) &&
    		   classA.Equals(classA.ClassB2.ClassA) &&
    		   classA.ClassB1.ClassA.Equals(classA.ClassB2.ClassA))
    		{
    			Console.WriteLine("They are the same object.");
    		}
    	}
    }
