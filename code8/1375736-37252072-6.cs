    using System;
    using System.Collections.Generic;
    using System.Linq;
    				
    public class Program
    {
    	public static void Main()
    	{
    		var people = new Person[0];
    		
    		var filtered = people.Apply(
                BooleanConnective.AndAlso,
                p => p.FirstName.StartsWith("J"),
                p => p.FirstName.StartsWith("A"));
    	}
    }
    
    public class Person
    {
    	public string FirstName { get; }
    	public string LastName { get; }
    }
