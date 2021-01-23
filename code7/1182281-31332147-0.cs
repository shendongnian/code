    using System;
    using System.Collections.Generic;
    
    public class Program
    {
    	public static void Main()
    	{
    		MyList dummy1 = new MyList("dummy1");
    		MyList dummy2 = new MyList("dummy2");
    		MyList dummy3 = new MyList("dummy3");
    		MyList dummy4 = new MyList("dummy4");
    		
    		Dictionary<int, MyList> _d = new Dictionary<int, MyList>()
    		{
    		  	{1, dummy1},
    		  	{2, dummy2}, 
    		  	{3, dummy3}, 
    		  	{4, dummy4}, 
    		};
    		
    		foreach (var key in _d.Keys)
    		{
    			Console.WriteLine(_d[key].Name);
    		}
    	}
    }
    
    public class MyList : List<String>
    {
    	private string name;
    	public string Name
    	{
    		get
    		{
    			return name;
    		}
    	}
    
    	public MyList(string name)
    	{
    		this.name = name;
    	}
    }
