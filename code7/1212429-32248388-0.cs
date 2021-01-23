    class Program
    {
        static void Main(string[] args)
        {
            Task t = Task.Factory.StartNew(() =>
            {
                //New thread starts here.
                LongRunningThread();
            });
            Console.WriteLine("Thread started");
            t.Wait(); //Wait for thread to complete (optional)
            Console.WriteLine("Thread complete");
            Console.ReadKey();
        }
    
        static void LongRunningThread()
        {
            Console.WriteLine("Doing work");
            //do work here
        }
    }
