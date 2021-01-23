    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace BGToTPL
    {
    	class Program
    	{
    		static void Main(string[] args)
    		{
    			Task[] tasks = new Task[20];
    			//Parent task is starting 20 child tasks
    			var parentTask = Task.Run(() =>
    			{
    				Console.WriteLine("Parent threadid: " + System.Threading.Thread.CurrentThread.ManagedThreadId);
    				for (int i = 0; i < 20; i++)
    				{
    					tasks[i] = Task.Factory.StartNew(() =>
    					{
    						Console.WriteLine("Child threadid: " + System.Threading.Thread.CurrentThread.ManagedThreadId);						
    						Task.Delay(15000);
    					});
    				}
    			});
    
    			parentTask.Wait();
    
    			Console.WriteLine("Parent task has started creating and running all the child tasks, now waiting for child tasks to be over.");
    
    			//Now wait for all the tasks to be done
    			Task.WaitAll(tasks);
    
    			Console.WriteLine("All the tasks are done");
    			Console.ReadKey();
    		}
    	}
    }
