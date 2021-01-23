        static void Main(string[] args)
        {
            var task = DoWorkAsync();
            task.Wait();
            // handle  results
            // task.Result;
 
            Console.WriteLine("Done.");
        }
        
        async static Task<bool> DoWorkAsync()
        {
            const int NUMBER_OF_SLOTS = 10;
            string param1="test";
            string param2="test";
            var results = new bool[NUMBER_OF_SLOTS]; 
            AsyncWorkScheduler ws = new AsyncWorkScheduler(NUMBER_OF_SLOTS);
            for (int i = 0; i < 1000; ++i)
            {
                await ws.ScheduleAsync((slotNumber) => DoWorkAsync(i, slotNumber, param1, param2, results));
            }
            ws.Complete();
            await ws.Completion;
        }
        async static Task DoWorkAsync(int index, int slotNumber, string param1, string param2, bool[] results)
        {
            
           MyClass cls = new MyClass();
           bool bRet = await cls.Method1Async(param1, param2, i); // takes up to 2 minutes to finish
            results[slotNumber] = results[slotNumber] && bRet;
        
        }
