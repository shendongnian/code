    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    public class Program
    {
    	public static void Main()
    	{
    		Course course = new Course {
    			CourseId = 123456,
    			Name = "Math",
    			Students = new List<Student>()
    		};
    		
    		course.Students.Add(new Student() {
    			ID = 11111,
    			Name = "John Doe"
    		});
    		course.Students.Add(new Student() {
    			ID = 22222,
    			Name = "Jane Doe"
    		});
    		
    		Console.WriteLine(course.FormatDetailsForDisplay());
    	}
    }
    
    public class Course
    {
        public int CourseId { get; set; }
        public string Name { get; set; }
        public List<Student> Students { get; set; }
    	
    	public string FormatDetailsForDisplay()
    	{
    		return String.Format("Course ID: {0} - Name: {1}\r\n{2}", 
    							 this.CourseId, 
    							 this.Name,
    							 String.Join("", this.Students.Select(s => s)));
    	}
    }
    
    public class Student
    {
    	public int ID { get; set; }
    	public string Name { get; set; }
    	
    	public override string ToString()
    	{
    		return String.Format("\tID: {0} - Name: {1}\r\n", ID, Name);
    	}
    }
