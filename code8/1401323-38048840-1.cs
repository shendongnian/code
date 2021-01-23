    using System;
    using System.Threading.Tasks;
    
    public class Program
    {
    	private static int counter = 0;
    	
    	public static void Main()
    	{
    		Random rnd = new Random();
    		var tasks = new Task<object>[]
            {
                CreateTask(rnd.Next(500,2000)).ContinueWith(t => (object)t.Result),
                CreateOtherTask(rnd.Next(500,2000)).ContinueWith(t => (object)t.Result),
                CreateTask(rnd.Next(500,2000)).ContinueWith(t => (object)t.Result),
                CreateOtherTask(rnd.Next(500,2000)).ContinueWith(t => (object)t.Result),
                CreateTask(rnd.Next(500,2000)).ContinueWith(t => (object)t.Result),
                CreateOtherTask(rnd.Next(500,2000)).ContinueWith(t => (object)t.Result),
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
    
    	private static async Task<Message> CreateOtherTask(int delay)
    	{
    		int id = Program.counter++;
    		await Task.Delay(delay);
    		return new Message("Task [" + id + "] delayed: " + delay);
    	}
    	
    	public class Message {
    		private string message;
    		
    		public Message(string msg) { message = msg; }
    		
    		public override string ToString(){ return message; }
    	}
    }
