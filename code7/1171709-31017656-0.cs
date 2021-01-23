    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    public enum Gender
    {
        Female, Male
    }
    
    public class Person
    {
        public string Name { get; private set; }
        public Gender Gender { get; private set; }
    
        public Person(string name, Gender gender)
        {
            Name = name;
            Gender = gender;
        }
    }
    
    public class Program
    {
	    public static void Main()
	    {
		    var persons = new[] { new Person("Cheryl Cole", Gender.Female), new Person("David Cameron", Gender.Male) };
            
		    var mCount = persons.Count(p => p.Gender == Gender.Male);
		    var fCount = persons.Count(p => p.Gender == Gender.Female);
		    
		    Console.WriteLine("mCount = {0}", mCount);
		    Console.WriteLine("fCount = {0}", fCount);
	    }
    }
