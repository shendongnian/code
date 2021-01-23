    var timer = new Stopwatch();        
    for (int i = 0; i < 10; i++)
    {
        timer.Start();
        var expression = new Expression('x');
        timer.Stop();
        Console.WriteLine(timer.ElapsedTicks);
        timer.Reset();
     }
