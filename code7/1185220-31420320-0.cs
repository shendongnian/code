    using System;
    using System.Threading;
    using System.Threading.Tasks;
    
    
    public class Program
    {
    	public static void Main()
    	{
    		Console.WriteLine("{0}: Starting Main: Thread ID {1}", DateTime.Now.TimeOfDay, Thread.CurrentThread.ManagedThreadId);
    		var finalTask = Task.Delay(500)
    			.ContinueWith(_ => {
    				Console.WriteLine("{0}: First Continue With: Task ID {1}, Thread ID {2}", DateTime.Now.TimeOfDay, Task.CurrentId, Thread.CurrentThread.ManagedThreadId);
    				Thread.Sleep(1000);
    			})
    			.ContinueWith(_ => {
    				Console.WriteLine("{0}: Second Continue With: Task ID {1}, Thread ID {2}", DateTime.Now.TimeOfDay, Task.CurrentId, Thread.CurrentThread.ManagedThreadId);
    				Thread.Sleep(1000);
    			});;
    		
    		finalTask.Wait();
    		Console.WriteLine("{0}: Finished!", DateTime.Now.TimeOfDay);
    	}
    }
