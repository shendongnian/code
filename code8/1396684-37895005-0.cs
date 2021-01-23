    long num_steps = 100000000;
    var sum = new ThreadLocal<double>(true);
    var step = 1.0 / num_steps;
    Stopwatch timer = Stopwatch.StartNew();
    Parallel.For(1, num_steps + 1, new ParallelOptions { MaxDegreeOfParallelism = 4 }, i =>
    {
        var x = (i - 0.5) * step;
        sum.Value = sum.Value + 4.0 / (1.0 + x * x);
    });
    var pi = step * sum.Values.Sum();
    timer.Stop();
    sum.Dispose();
    Console.WriteLine("\n pi with {0} steps is {1} in {2} miliseconds ", num_steps, pi, (timer.ElapsedMilliseconds));
    Console.ReadKey();
