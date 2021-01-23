    using System;
    
    namespace Program
    {
    	public class Program
    	{
    		public static void Main()
    		{
    			Dog rex = new Dog();
    			Animal rexAsAnimal = rex;
    			
    			// Can access 'MakeSound' due the fact it declared at Dog (Inherited by Animal)
    			Console.WriteLine(rex.MakeSound()); // Output: Bark
    			
    			// Compilation error: rexAsAnimal is defined as 'Animal' which doesn't have the 'Bark' method.
    			//Console.WriteLine(rexAsAnimal.Bark()); // Output when uncomment: Compilation error.
    			
    			// Explicitly telling the compiler to cast the object into "Dog"
    			Console.WriteLine(((Dog)rexAsAnimal).Bark()); // Output: Bark
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
