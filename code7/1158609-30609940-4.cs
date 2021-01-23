    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    
    public class Program
    {
    	public static void Main()
    	{
    		ListOfVariablesToSave myListOfVariablesToSave = new ListOfVariablesToSave();
    
    		foreach (PropertyInfo pi in myListOfVariablesToSave
    				 .GetType()
    				 .GetProperties( BindingFlags.Public | 
    								 BindingFlags.Instance | 
    								 BindingFlags.DeclaredOnly )
                     // Only get the properties of type List<int>
                     // Actual PropertyType looks like: 
                     //   System.Collections.Generic.List`1[System.Int32]
    				 .Where(p => p.PropertyType.ToString().Contains("List") && 
    						p.PropertyType.ToString().Contains("System.Int32"))
    				)
    		{
    			Console.WriteLine(pi.Name);
    			(pi.GetValue(myListOfVariablesToSave) as List<int>).ForEach(i => Console.WriteLine(i));
    		}
    	}
    }
    
    public class ListOfVariablesToSave : List<List<int>>
    {
    	public List<int> controlDB { get; set; }
    	public List<int> interacDB { get; set; }
        // Added this property to show that it doesn't get used in the above foreach
    	public int Test {get; set;}
    
    	public ListOfVariablesToSave()
    	{
    		controlDB = new List<int> { 1, 2, 3 };
    		interacDB = new List<int> { 21, 22, 23 };
    		Add(controlDB);
    		Add(interacDB);
    	}
    }
