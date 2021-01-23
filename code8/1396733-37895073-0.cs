    using System;
    using System.Collections.Generic;
    
    public class Student
    {
         public string studentName { get;set;}
         public long studentID;
         public int score1;
    }
    
    public class Test
    {
    	public static void Main()
    	{
    		 var students = new List<Student>();
             for (int i = 0; i < 3; i++)
             {
                 Console.WriteLine("Student {0}", i + 1);
                 Console.Write("\t \t Name: ");
                 string input = Console.ReadLine();
                 students.Add(new Student {studentName = input });
             }                     
    	}
    }
