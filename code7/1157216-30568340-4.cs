    static void Main(string[] args)
    {
        Thread t = new Thread(WriteX);
        t.Start();
        backgroundThreadReady.WaitOne(); // wait for background thread to be ready
        startThreadRace.Set();           // signal your background thread to start the race
        for (int i = 0; i < 1000; i++)
        {
            Console.Write("O");
        }
    }
