    using System;
    					
    public class Program
    {
    	public class Parent 
    	{
    		public override string ToString() 
    		{
    			return "I AM THE PARENT";
    		}	
    	}
    		
    	public class Child : Parent
    	{
    		public override string ToString() 
    		{
    			return "I AM THE CHILD";
    		}	
    	}
    	
    	public static void Main()
    	{
    		Parent parent = new Parent(); 
    		Parent pAsChild = new Child();  
    		//Child child = new Parent(); does not compile
    		
    		Console.WriteLine("{0}", parent.ToString());
    		Console.WriteLine("{0}", pAsChild.ToString());
    	}
    }
