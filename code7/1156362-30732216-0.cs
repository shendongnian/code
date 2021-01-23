	class Program
    {
        private static void ThreadRoutine(object state)
        {
            var player = new MediaPlayer();
            var iteration = (int)state;
            if (iteration % 1000 == 0)
            {
                Console.WriteLine("Executed: " + state);
            }
        }
        static void Main(string[] args)
        {
            for (int i = 0; i < 10000000; i++)
            {
                if (i % 1000 == 0)
                {
                    Console.WriteLine("Queued: " + i);
                }
                ThreadPool.QueueUserWorkItem(ThreadRoutine, i);
            }
        }
    }
