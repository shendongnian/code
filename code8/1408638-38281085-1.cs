    using System;
    using System.Collections.Generic;
    
    public class Program
    {
    	public static void Main()
    	{
    		var c = new CollectionClass();
    		var watch = System.Diagnostics.Stopwatch.StartNew();
    		for (var i = 0; i < 10000; i++)
    			c.Test1();
    		watch.Stop();
    		Console.WriteLine("Test1:" + watch.ElapsedMilliseconds);
    
    		watch = System.Diagnostics.Stopwatch.StartNew();
    		for (var i = 0; i < 10000; i++)
    			c.Test2();
    		watch.Stop();
    		Console.WriteLine("Test2:" + watch.ElapsedMilliseconds);
    
    		watch = System.Diagnostics.Stopwatch.StartNew();
    		for (var i = 0; i < 10000; i++)
    			c.Test3();
    		watch.Stop();
    		Console.WriteLine("Test3:" + watch.ElapsedMilliseconds);
    
    		watch = System.Diagnostics.Stopwatch.StartNew();
    		for (var i = 0; i < 10000; i++)
    			c.Test4();
    		watch.Stop();
    		Console.WriteLine("Test4:" + watch.ElapsedMilliseconds);
    	}
    }
    
    internal class CollectionClass
    {
    	public List<string> ListData { get; set; }
    
    	public void Test1()
    	{
    		ListData = new List<string>();
    		string[] names = { "Matt", "Joanne", "Robert" };
    		
    		foreach (var item in names)
    			ListData.Add(item);
    	}
    
    	public void Test2()
    	{
    		string[] names = { "Matt", "Joanne", "Robert" };
    		ListData = new List<string>();
    		ListData.AddRange(names);
    	}
    
    	public void Test3()
    	{
    		ListData = new List<string>();
    		ListData.Add("Matt");
    		ListData.Add("Joanne");
    		ListData.Add("Robert");
    	}
    
    	public void Test4()
    	{
    		ListData = new List<string>(){ "Matt", "Joanne", "Robert" };
    	}
    }
