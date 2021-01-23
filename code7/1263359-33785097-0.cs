    using System;
    using System.Threading;
    using System.Threading.Tasks;
    
    class Test
    {
        static void Main()
        {
            Func<Task> func = FuncAsync;
            Task task = Task.Run(func);
            for (int i = 0; i < 7; i++)
            {
                Console.WriteLine(task.Status);
                Thread.Sleep(1000);
            }        
        }
        
        private static async Task FuncAsync()
        {
            await Task.Delay(TimeSpan.FromSeconds(5));
        }
    }
