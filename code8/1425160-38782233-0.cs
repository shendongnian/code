    static void Main()
    {
        Task[] tasks = new Task[4];
        for (int i = 0; i < 4; i++)
        {
            int x = i;
            tasks[x] = Task.Factory.StartNew(() => {
                Console.WriteLine(x);
            });
        }
        Console.ReadKey();
    }
