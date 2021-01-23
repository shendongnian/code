        static void Main(string[] args)
        {
            var task = DoWorkAsync();
            task.Wait();
            Console.WriteLine("Done.");
        }
        async static Task DoWorkAsync()
        {
            const int NUMBER_OF_SLOTS = 10;
            
            AsyncWorkScheduler ws = new AsyncWorkScheduler(NUMBER_OF_SLOTS);
            for (int i = 0; i < 1000; ++i)
            {
                await ws.ScheduleAsync((slotNumber) => DoWorkAsync(i, slotNumber));
            }
            ws.Complete();
            await ws.Completion;
        }
        async static Task DoWorkAsync(int index, int slotNumber)
        {
            Console.WriteLine("DoWorkAsync(index = {0}, slotNumber={1}).Started, ThreadId={2}", index, slotNumber, Thread.CurrentThread.ManagedThreadId);
            await Task.Delay(100);
            Console.WriteLine("DoWorkAsync(index = {0}, slotNumber={1}).Completed, ThreadId={2}", index, slotNumber, Thread.CurrentThread.ManagedThreadId);
        }
