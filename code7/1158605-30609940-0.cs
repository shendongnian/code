    using System;
    using System.Collections.Generic;
    using System.Reflection;
    
    public class Program
    {
    	public static void Main()
    	{
    		ListOfVariablesToSave myListOfVariablesToSave = new ListOfVariablesToSave();
    
    		foreach (PropertyInfo pi in myListOfVariablesToSave
    				 .GetType()
    				 .GetProperties( System.Reflection.BindingFlags.Public | 
    								 System.Reflection.BindingFlags.Instance | 
    								 System.Reflection.BindingFlags.DeclaredOnly )
    				)
    		{
    			Console.WriteLine(pi.Name);
                // This only works if your properties are List<int>, 
                // other property types will throw an exception 
    			(pi.GetValue(myListOfVariablesToSave) as List<int>).ForEach(i => Console.WriteLine(i));
    		}
    	}
    }
    
    public class ListOfVariablesToSave : List<List<int>>
    {
    	public List<int> controlDB { get; set; }
    	public List<int> interacDB { get; set; }
    
    	public ListOfVariablesToSave()
    	{
    		controlDB = new List<int> { 1, 2, 3 };
    		interacDB = new List<int> { 21, 22, 23 };
    		Add(controlDB);
    		Add(interacDB);
    	}
    }
