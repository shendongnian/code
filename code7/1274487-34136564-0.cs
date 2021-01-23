    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    public class StudentClass
    {
    	private string _storedStudentName;
    	public static List<StudentClass> GetStudents()
    	{
    		List<StudentClass> ListOfStudents = new List<StudentClass>();
    		ListOfStudents.Add(new StudentClass("Jane"));
    		ListOfStudents.Add(new StudentClass("Alex"));
    		ListOfStudents.Add(new StudentClass("Mike"));
    		ListOfStudents.Add(new StudentClass("James"));
    		ListOfStudents.Add(new StudentClass("Julia"));
    		return ListOfStudents;
    	}
    	
    	public string Name
    	{
    		get
    		{
    			return _storedStudentName;
    		}
    	}
    	
    	public StudentClass(string StudentName)
    	{
    		_storedStudentName = StudentName;
    	}
    }
