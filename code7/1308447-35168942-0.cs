    using System;
    using System.Collections.Generic;
    public class Program
    {
	public static void Main()
	{
		Console.WriteLine("Hello World");
		var cl = new cl();
		populate(cl.dict);
		
		foreach(var d in cl.dict)
			Console.WriteLine(d.Key);
	}
	private static void populate(Dictionary<int, string> d)
	{
		for (int i = 0; i < 10 ;  i++)
		{
			if (!d.ContainsKey(i))
			{
				d.Add(i, i.ToString());
			}
		}
	    }
    }
    public class cl
    {
	    public Dictionary<int, string> dict;
	    public cl()
	     {
		   dict = new Dictionary<int, string>();
	     }
     }
