    public static void Main(string[] args)
    {
    try{
        Task[] tasks = new Task[200];
        for (int i = 0; i < 200; i++)
        {
            tasks[i] = Task.Factory.StartNew(() => RunningThread());
        }
        Task.WaitAll(tasks);
        Console.WriteLine("finish...");
        Console.ReadKey();
        //.....
    }
    catch(Exception ex)
    {
     Console.WriteLine(ex.Message); <<<--(break point here)
    }
    }
