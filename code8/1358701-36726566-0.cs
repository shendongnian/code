    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    namespace Example
    {
    	internal class Program
    	{
    		public static void Main(string[] args)
    		{
    			var myClassList = new List<MyClass> {new MyClass(), new MyClass()};
    			myClassList.ElementAt(0).ValueId = 1;
    			myClassList.ElementAt(0).ValueTwoId = 2;
    			myClassList.ElementAt(1).ValueId = 3;
    			myClassList.ElementAt(1).ValueTwoId = 4;
    
    			var resultList = myClassList
    				.Where(x => x.ValueId != null && x.ValueTwoId != null)
    				.SelectMany(x => new List<int> { x.ValueId.Value, x.ValueTwoId.Value})
    				.ToList();
    
    			foreach (var i in resultList)
    			{
    				Console.WriteLine(i);
    			}
    			//Prints out:
    			//1
    			//2
    			//3
    			//4
    			Console.ReadLine();
    		}
    
    		public class MyClass
    		{
    			public int? ValueId;
    			public int? ValueTwoId;
    		}
    	}
    }
