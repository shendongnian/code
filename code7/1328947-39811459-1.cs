    static void Main()
    {
        Task<int> longTask = Task.Run(() => {Thread.Delay(1000);
                                             return 1;}
        Console.WriteLine("I'm writing something while the task is running...");
        Console.WriteLine(longTask.Result);
    }
