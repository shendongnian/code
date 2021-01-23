    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    
    public class ObjectWithSize
    {
    	public int Size {get; set;}
    	public ObjectWithSize(int size)
    	{
    		Size = size;
    	}
    }
    
    public class Program
    {
    	public static void Main()
    	{
    		Console.WriteLine("start");
    		var list = new List<ObjectWithSize>();
    		list.Add(new ObjectWithSize(12));
    		list.Add(new ObjectWithSize(13));
    		list.Add(new ObjectWithSize(14));
    		list.Add(new ObjectWithSize(14));
    		list.Add(new ObjectWithSize(18));
    		list.Add(new ObjectWithSize(15));
    		list.Add(new ObjectWithSize(15));
    		var duplicates = list.GroupBy(x=>x.Size)
                  .Where(g=>g.Count()>1);
    		foreach (var dup in duplicates)
    			foreach (var objWithSize in dup)
    				Console.WriteLine(objWithSize.Size);
    	}
    }
