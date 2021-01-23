    using System;
    using System.Threading.Tasks;
    
    public class Program
    {
    	private static int counter = 0;
    	
    	public static void Main()
    	{
    		Random rnd = new Random();
    		var tasks = new Task<string>[]
            {
                CreateTask(rnd.Next(500,2000)),
                CreateTask(rnd.Next(500,2000)),
                CreateTask(rnd.Next(500,2000)),
                CreateTask(rnd.Next(500,2000)),
                CreateTask(rnd.Next(500,2000)),
                CreateTask(rnd.Next(500,2000)),
            };		
    		
    		Task.WaitAll(tasks);
    		foreach(var t in tasks)
    			Console.WriteLine(t.Result);
    		
    		// They are already completed here, but just to show the syntax.
    		// .Result should obvisously be awaited instead.
    		var all = Task.WhenAll(tasks).Result;
    		foreach(var result in all)
    			Console.WriteLine(result);
    	}
    
    	private static async Task<string> CreateTask(int delay)
    	{
    		int id = Program.counter++;
    		await Task.Delay(delay);
    		return "Task [" + id + "] delayed: " + delay;
    	}
    }
