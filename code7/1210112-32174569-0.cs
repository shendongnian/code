    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    					
    public class Program
    {
    	public static void Main()
    	{
    		var doWork = new SomeWorkClass();
    		
    		var list1Task = doWork.GetList1Async();
    		var list2Task = doWork.GetList2Async();
    		
    		var list1 = list1Task.Result;
    		var list2 = list2Task.Result;
    		
    		var newList = list1.Concat(list2).ToList();
    		
    		foreach(var str in newList) {
    			Console.WriteLine(str);
    		}
    	}
    }
    
    public class SomeWorkClass
    {
    	private List<string> _list1 = new List<string>() { "Some text 1", "Some other text 2" };
    	private List<string> _list2 = new List<string>() { "Yet more text 3" };
    	
    	public async Task<List<string>> GetList1Async()
    	{
    		await Task.Delay(1000);
    		return _list1;
    	}
    	
    	public async Task<List<string>> GetList2Async()
    	{
    		await Task.Delay(700);
    		return _list2;
    	}
    }
