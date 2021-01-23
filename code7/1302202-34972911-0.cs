    using System;
    using System.Collections;
    					
    public class Program
    {
    	public static void Main()
    	{
    		var students = new ArrayList();
    		students.Add(new Student() { FirstName = "John", LastName = "Doe" });
    		students.Add(new Student() { FirstName = "Richard", LastName = "Roe" });
    		
    		foreach(Student s in students)
    		{
    			Console.WriteLine(s.FirstName);
    		}
    	}
    }
    
    public class Student
    {
    	public string FirstName {get;set;}
    	public string LastName {get;set;}	
    }
