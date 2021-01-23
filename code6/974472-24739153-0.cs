    static void Main(string[] args)
    {
        var task = new Task(() => 
        {         
            while (true)
            {
                Console.WriteLine("Computing..");
                Thread.Sleep(1000);
            }
        });
        task.Start();
        task.Wait(); //Wait for the task to finish
    }
