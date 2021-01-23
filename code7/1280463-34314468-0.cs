    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    public class Program
    {
    	public static void Main()
    	{
    		var list = new List<Item>{
    			new Item { Id = 2, Text = "A" },
    			new Item { Id = 4, Text = "B" },
    			new Item { Id = 3, Text = "C" },
    			new Item { Id = 5, Text = "D" },
    			new Item { Id = 1, Text = "E" }
    		};
    		var sortorder = new List<int> { 1, 3, 2, 5, 4 };
    		
    		var sortedlist = sortorder.Join(list, x => x, y => y.Id, (x,y) => y);
    		
    		foreach(var item in sortedlist) 
    			Console.WriteLine("{0} {1}", item.Id, item.Text);
    	}
    }
