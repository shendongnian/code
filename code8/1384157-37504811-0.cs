    using System;
    					
    public class Program
    {
    	public static void Main()
    	{
    		string dog = "Dog";
    		var dogObj = Activator.CreateInstance(Type.GetType(dog)) as Animal;
    		string cat = "Cat";
    		var catObj = Activator.CreateInstance(Type.GetType(cat)) as Animal;
    		Console.WriteLine(dogObj);
    		Console.WriteLine(catObj);
    	}
    }
    
    public abstract class Animal
    {
    	public override string ToString() { return "Type: " + GetType().Name; }
    }
    
    public class Cat : Animal
    {
    }
    
    public class Dog : Animal
    {
    }
