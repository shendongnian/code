    static async Task JobAsync()
    {
        Task t = Task.Run(() => Job(ConsoleColor.Red, 2));
        Job(ConsoleColor.Green, 1);
        await t;
        Job(ConsoleColor.Blue, 1);
    }
    public static async Task Main()
    {
        Task t = JobAsync();
        Job(ConsoleColor.White, 1);
        await t;
    }
 
