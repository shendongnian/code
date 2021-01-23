    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Threading;
    
    namespace MyConsole
    {
        class Program
        {
            static void Main(string[] args)
            {
                Program console = new Program();
                console.MyMethodAsync();
            }
    
            void ExecuteAfterTimeInterval()
            {
                //some code
            }
    
            public async Task MyMethodAsync()
            {
                Task<int> longRunningTask = LongRunningOperationAsync();
    
                // run the below code in separate thread
                //some code here 
                //some code here
                for (int i = 0; i < 10000000000; i++)
                {
                    Console.WriteLine(i); //SET BREAK POINT HERE
                }
                //some code here
    
                //and now we call await on the task 
                int result = await longRunningTask;
            }
    
            public async Task<int> LongRunningOperationAsync() // assume we return an int from this long running operation 
            {
    
                bool retry = true;
    
                using (AutoResetEvent wait = new AutoResetEvent(false))
                {
                    while (retry)
                    {
    
                        //Do Work here
                        //await Task.Delay(43200000); //12 hour delay
                        await Task.Delay(3000); //SET BREAK POINT HERE
                    }
                }
    
                return 1;
            }
        }
    }
