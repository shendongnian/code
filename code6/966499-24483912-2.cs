    List<TimeSpan> elapsedTimes = new List<TimeSpan>();
    Stopwatch sw = new Stopwatch();
    Stopwatch sw2 = new Stopwatch();
    sw.Start();
    Thread.Sleep(2000); // just to get some time on our stopwatch
    sw.Stop();
    sw2.Start();
    Thread.Sleep(1500); // just to get some time on our stopwatch
    sw2.Stop();
    // add timespans
    TimeSpan span1 = TimeSpan.FromTicks(sw.Elapsed.Ticks);
    elapsedTimes.Add(span1);
    TimeSpan span2 = TimeSpan.FromTicks(sw2.Elapsed.Ticks);
    elapsedTimes.Add(span2);
    double seconds = elapsedTimes.Sum(x => x.TotalSeconds);
