The below code executes without any errors or warnings. But when you execute the code the program exits silently. What you might be expecting is the program waits for the task to complete, asks the user to press any key and exit. Whenever an await statement is executed the control goes back to the invoking step. In our case after the step await task; is executed, before the task completes the control goes back to the invoking step SomeTask(); and the program exits.
    
    class Program
    {
        static void Main(string[] args)
        {
            SomeTask();
        }
    
        public static async void SomeTask()
        {
            Task task = Task.Run(() =>
            {
                System.Threading.Thread.Sleep(20000);
                Console.WriteLine("Task Completed!");
            });
            await task;
            Console.WriteLine("Press any key to exit");
            Console.ReadLine();
        }
    }
To fix this, add await to the SomeTask(); call so that the program waits for async SomeTask() to complete.
    
    class Program
    {
        static void Main(string[] args)
        {
            await SomeTask();
        }
    
        public static async Task SomeTask()
        {
            Task task = Task.Run(() =>
            {
                System.Threading.Thread.Sleep(20000);
                Console.WriteLine("Task Completed!");
            });
            await task;
            Console.WriteLine("Press any key to exit");
            Console.ReadLine();
        }
    }
