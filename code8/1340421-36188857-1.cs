    static void Main(string[] args)
    {
        var num = "2345678901";
        Stopwatch timer = new Stopwatch();
        timer.Start();
        foreach (var number in getnums(num))
        {
            // Yum yum numbers
        }
        timer.Stop();
        Console.WriteLine(timer.Elapsed.Ticks);
        timer.Reset();
        timer.Start();
        foreach (var number in DoIt(num))
        {
            // Yum yum numbers
        }
        timer.Stop();
        Console.WriteLine(timer.Elapsed.Ticks);
    }
