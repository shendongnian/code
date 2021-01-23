    class Program
    {
        static int stageOfA = 0;
        static int stageOfB = 0;   
        private static readonly AutoResetEvent _signalStageCompleted = new AutoResetEvent(false);
        static void DoA()
        {
            for (int i = 0; i < 3; i++) {
                Thread.Sleep(100);
                Interlocked.Increment(ref stageOfA);
                Console.WriteLine($"A reached {stageOfA}");
                _signalStageCompleted.Set();
            }
        }
        static void DoB()
        {
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(50);
                Interlocked.Increment(ref stageOfB);
                Console.WriteLine($"B reached {stageOfB}");
                _signalStageCompleted.Set();
            }
        }
        static void DoAfterB5andA1()
        {
            while( (stageOfA < 1) || (stageOfB < 5))
            {
                Console.WriteLine($"Task 3 still waiting: A{stageOfA}, B{stageOfB}");
                _signalStageCompleted.WaitOne();
            }
            Console.WriteLine($"Task 3 done: A{stageOfA}, B{stageOfB}");
        }
        static void Main(string[] args)
        {
            Task[] taskArray = { Task.Factory.StartNew(() => DoA()),
                                     Task.Factory.StartNew(() => DoB()),
                                     Task.Factory.StartNew(() => DoAfterB5andA1()) };
            Task.WaitAll(taskArray);
            Console.WriteLine("All done");
            Console.ReadLine();
        }
    }
