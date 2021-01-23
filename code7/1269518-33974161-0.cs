    using System;
    
    namespace Program
    {
    	public class Program
    	{
    		public static void Main()
    		{
    			Dog rex = new Dog();
    			Animal rexAsAnimal = rex;
    			
    			Console.WriteLine(rex.MakeSound()); // Can access 'MakeSound' due the fact it declared at Dog (Inherited by Animal)
    			Console.WriteLine(rexAsAnimal.Bark()); // Compilation error: rexAsAnimal is defined as 'Animal' which doesn't have the 'Bark' method.
    		}
    	}
    	
    	public abstract class Animal
    	{
    		public abstract string MakeSound();
    	}
    	
    	public class Dog : Animal
    	{
    		public override string MakeSound() { return Bark(); }
    		public string Bark()
    		{
    			return "Bark";
    		}
    	}
    }
