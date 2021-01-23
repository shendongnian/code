    static Random r = new Random();
    
    void Main()
    {
         int iterations = 2000;
    
        Stopwatch s = new Stopwatch();
        s.Start();
    
        Parallel.For(0, iterations, ReadFile);
    
        s.Stop();
    
        Console.WriteLine("Total elapsed milliseconds was {0}.", s.ElapsedMilliseconds);
        Console.WriteLine("Total iterations were {0}.", iterations);
        Console.WriteLine("Total iterations per second was {0}.", iterations / s.Elapsed.TotalSeconds);
    }
    
    // Define other methods and classes here
    static async void ReadFile(int x)
    {
        string path = @"C:\Temp\random.txt";
        int readSize = r.Next(512, 10 * 1024);
        using (StreamReader reader = new StreamReader(path))
        {
            await reader.ReadAsync(new char[readSize], 0, readSize);
        }
    }
