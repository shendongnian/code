    public static void Main() 
    {       
        Task<string> task = AsyncDemo.TestMethod();
        
        Console.WriteLine("In AsyncMain.Main() Thread {0} does some work.", Thread.CurrentThread.ManagedThreadId);
        string returnValue = task.Result; // This will cause the main thread to block until the result returns.
        Console.WriteLine("The async call executed on thread {0}, has responded with \"{1}\". The result is {2}", threadId, returnValue, result);
    }
    
    public class AsyncDemo 
    {   
        // The method to be executed asynchronously.
        public async static Task<string> TestMethod() 
        {
            Console.WriteLine("TestMethod() begins");
    
            //Do work
    
            await new WebClient().UploadStringTaskAsync("...", "...");
    
            return String.Format("I'm finished my work.");
        }
    }
