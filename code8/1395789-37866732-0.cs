        using System;
    using System.Collections.Generic;
    using System.Linq;
    					
    public class Program
    {
    	public static void Main()
    	{
    		var s1=new Student(){Id=0, Name="Student 1", Score=56.44};
    		var s2=new Student(){Id=1, Name="Student 1", Score=34.45};
    		var s3=new Student(){Id=2, Name="Student 2", Score=56.23};
    		var s4=new Student(){Id=3, Name="Student 2", Score=98.54};
		
		var list=new List<Student>(){s1,s2,s3,s4};
		
		var select=list.OrderBy(x=>x.Score).GroupBy(x=>x.Name);
		
		var newList=new List<Student>();
		
		foreach (var item in select){
		
			newList.Add(item.First());
		
		}
		
		foreach (var item in newList){
		
			Console.WriteLine(item.Id +"/"+item.Name +"/"+item.Score);
		}
	}
	
	public class Student
	{
		public int Id {get;set;}
		public string Name {get;set;}
		public double Score {get;set;}
    	}
      }
