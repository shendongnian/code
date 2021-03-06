    static void Main(string[] args)
    {
        Task t = Task.Run(DoSthAsync);
        t.Wait();
        Console.WriteLine("Finished?");
    }
    static async Task DoSthAsync()
    {
        using (StreamReader reader = new StreamReader("file.txt"))
        {
            int i = 1;
            while (!reader.EndOfStream)
            {
                Console.WriteLine("{0}: {1}", i++, await reader.ReadLineAsync());
            }
        }
    }
