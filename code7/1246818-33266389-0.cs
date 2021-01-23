    using System;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    					
    public class Program
    {
    	public static void Main()
    	{	
    		Console.WriteLine("Starting Parent Task");
    		 List<Task> taskList = new List<Task>();
    		 Task parentTask = Task.Factory.StartNew(() =>
    		 {
    			for (int i = 0; i <= 5; i++)
    			{
    				var task = new Task(() => Console.WriteLine("Task Running : " + Task.CurrentId), TaskCreationOptions.AttachedToParent);
    				taskList.Add(task);
    			}
    			 
    			foreach (Task t in taskList)
    			{
    				t.Start();
    			}
    			
    			Task.WaitAll(taskList.ToArray());
    
    		 });
    	
    		
    		Console.WriteLine("Parent Task Ending");
    		
    	}
    }
