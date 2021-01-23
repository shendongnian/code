    using System;
    using System.Collections.Generic;
    					
    public class Program
    {
    	public static void Main()
    	{
    		MyPets pets = new MyPets();
    		pets.addPet(new Cat());
    		pets.addPet(new Terrier());
    		pets.itterate();
    	}
    }
    
    public abstract class Pet{
    	public abstract void makeNoise();
    }
    
    public abstract class Dog :Pet{
    	public override void makeNoise(){
    		Console.WriteLine("Dog is woofing");
    	}
    }
    
    public class Cat : Pet{
    	public void climbTree(){
    		Console.WriteLine("Cat is climbing");
    	}
    	
    	public override void makeNoise(){
    		Console.WriteLine("Cat is meowing");
    	}
    }
    
    public class Terrier: Dog{
    	public void growl(){
    		Console.WriteLine("Terrier is growling");
    	}
    	
    	public override void makeNoise(){
    		growl();
    	}
    }
    
    public class MyPets{
    	public MyPets(){
    		Pets = new List<Pet>();
    	}
    	
    	public List<Pet> Pets {get; private set;}
    	
    	public void addPet(Pet p){
    		Pets.Add(p);
    	}
    	
    	public void itterate(){
    		foreach(Pet p in Pets){
    			p.makeNoise();
    			if (p.GetType() == typeof(Cat)){
    				((Cat)p).climbTree();
    			}
    		}
    	}
    }
