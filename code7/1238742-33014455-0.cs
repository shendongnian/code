    // Console
    
        public class Program
        {
        	public static void Main(string[] args)
        	{
        		TaskDoer td = new TaskDoer();
        		td.doTask+=SomeTasks.StoreToSql;
        		td.doTask+=SomeTasks.SendEmail;
        		
        		td.StartTasks(5);
        	}
        }
    
    // delegate
    
        public delegate void Do(object o);
    
    // class which uses delegate
    
        public class TaskDoer
        {
        	public event Do doTask;
        	
        	public void StartTasks(object o)
        	{
        		doTask(o);
        	}
        }
    
    // class which provides method definitions that could be used with the delegate
    
        public class SomeTasks
        {
        	public static void StoreToSql(object o)
        	{
        		Console.WriteLine ("Stored to SQL");
        	}
        	
        	public static void SendEmail(object o)
        	{
        		Console.WriteLine ("Email Sent");
        	}
        }
