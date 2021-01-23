    object lockObject = new object();
    long num_steps = 100000000;
    Stopwatch timer = Stopwatch.StartNew();
    double step = 1.0 / num_steps;
    double sum = 0;
    Parallel.For(1, num_steps + 1, () => 0.0, (i, loopState, partialResult) =>
    {
        var x = (i - 0.5) * step;
        return partialResult + 4.0 / (1.0 + x * x);
    },
    localPartialSum =>
    {
        lock (lockObject)
        {
            sum += localPartialSum;
        }
    });
    var pi = step * sum;
    timer.Stop();
    Console.WriteLine("\n pi with {0} steps is {1} in {2} miliseconds ", num_steps, pi, (timer.ElapsedMilliseconds));
